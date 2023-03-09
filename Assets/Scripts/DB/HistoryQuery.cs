using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Mono.Data.Sqlite;
using System.Data;

/// <summary>
/// Se encarga de realizar la consulta para recoger los datos necesarios para ser mostrados en la pantalla de historial
/// </summary>
public class HistoryQuery : MonoBehaviour
{

    public GameObject P1Item;
    public GameObject P2Item;
    public CharacterDatabase characterDB;
    public GameObject Parent;

    private string dbName = @"URI=file:WoB.db";
   
    void Start()
    {
        GetData();
    }

   private void GetData()
    {
        using (var conn = new SqliteConnection(dbName))
        {
            conn.Open();


            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText = "SELECT * FROM players_history ORDER BY Id DESC;";
                int cont = 0;
                using ( IDataReader rd = cmd.ExecuteReader())
                {
                    float pos = Parent.transform.position.y+180;
                    while (rd.Read())
                    {
                        if (rd["WinnerID"].Equals(1))
                        {

                            GameObject Item = GameObject.Instantiate(P1Item);
                            Item.gameObject.SetActive(true);
                            Item.gameObject.transform.SetParent(Parent.transform);
                            Item.gameObject.GetComponent<RectTransform>().position = new Vector3(Parent.transform.position.x-100, pos, 0);



                            foreach (Transform ch in Item.transform)
                            {
                                if (ch.name.Equals("PlayerNumber"))
                                {
                                    ch.gameObject.GetComponent<TMPro.TextMeshProUGUI>().text = "Player 1";
                                }else if (ch.name.Equals("PlayerName"))
                                {
                                    ch.gameObject.GetComponent<TMPro.TextMeshProUGUI>().text = rd["Name"].ToString();
                                }
                                else if (ch.name.Equals("Date"))
                                {
                                    ch.gameObject.GetComponent<TMPro.TextMeshProUGUI>().text = rd["Date"].ToString().Split(' ')[0];
                                }
                                else if (ch.name.Equals("Result"))
                                {
                                    ch.gameObject.GetComponent<TMPro.TextMeshProUGUI>().text = rd["P1Score"].ToString() + " - " + rd["P2Score"].ToString();
                                }
                                else if (ch.name.Equals("Avatar"))
                                {
                                    string sprite = rd["WinnerSprite"].ToString();
                                    Character character = characterDB.GetCharacter(int.Parse(sprite));
                                    ch.gameObject.GetComponent<Image>().sprite = character.characterSprite;
                                }


                            }
                        }
                        else
                        {
                            GameObject Item = GameObject.Instantiate(P2Item);
                            Item.gameObject.SetActive(true);
                            Item.gameObject.transform.SetParent(Parent.transform);
                            Item.gameObject.GetComponent<RectTransform>().position = new Vector3(Parent.transform.position.x+100, pos, 0);


                            foreach (Transform ch in Item.transform)
                            {
                                if (ch.name.Equals("PlayerNumber"))
                                {
                                    ch.gameObject.GetComponent<TMPro.TextMeshProUGUI>().text = "Player 2";
                                }
                                else if (ch.name.Equals("PlayerName"))
                                {
                                    ch.gameObject.GetComponent<TMPro.TextMeshProUGUI>().text = rd["Name"].ToString();
                                }
                                else if (ch.name.Equals("Date"))
                                {
                                    ch.gameObject.GetComponent<TMPro.TextMeshProUGUI>().text = rd["Date"].ToString().Split(' ')[0];
                                }
                                else if (ch.name.Equals("Result"))
                                {
                                    ch.gameObject.GetComponent<TMPro.TextMeshProUGUI>().text = rd["P1Score"].ToString() + " - " + rd["P2Score"].ToString();
                                }
                                else if (ch.name.Equals("Avatar"))
                                {
                                    string sprite = rd["WinnerSprite"].ToString();
                                    Character character = characterDB.GetCharacter(int.Parse(sprite));
                                    ch.gameObject.GetComponent<Image>().sprite = character.characterSprite;
                                }


                            }
                        }

                        pos -= 100;
                        cont++;
                        if (cont == 9)
                        {
                            break;
                        }
                        //print(rd["ID"] + ", " + rd["WinnerID"] + ", " + rd["WinnerSprite"] + ", " + rd["Name"] + ", " + rd["P1Score"] + ", " + rd["P2Score"] + ", " + rd["Date"]);
                    }

                    rd.Close();
                }
            }

            conn.Close();
        }
    }
   
}
