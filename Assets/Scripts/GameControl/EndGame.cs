using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Mono.Data.Sqlite;
using System;

/// <summary>
/// Controla el final de la partida, mostrando la información necesaria por pantalla
/// </summary>
public class EndGame : MonoBehaviour
{
    public static bool End = false;
    public static int Winner = 0;
    public static int PlayerId = 0;
    public static int P1Score = 0;
    public static int P2Score = 0;

    public GameObject PlayerSprite;
    public GameObject PlayerName;
    public GameObject EndMenu;

    public CharacterDatabase characterDB;

    private Sprite image;
    private string Name;
    private string P1Name;
    private string P2Name;

    //DB
    private string dbName = @"URI=file:WoB.db";

    private void ChangeData()
    {
        Character character = characterDB.GetCharacter(Winner);
        image = character.characterSprite;
        Name = character.characterName;
        PlayerSprite.GetComponent<Image>().sprite = image;
        P1Name = PlayerPrefs.GetString("P1Name");
        P2Name = PlayerPrefs.GetString("P2Name");
        if (PlayerId == 1)
        {
            PlayerName.GetComponent<TMPro.TextMeshProUGUI>().text = P1Name;
            PlayerName.GetComponent<TMPro.TextMeshProUGUI>().color = new Color(255f, 0, 0);

        }
        else
        {
            PlayerName.GetComponent<TMPro.TextMeshProUGUI>().text = P2Name;
            PlayerName.GetComponent<TMPro.TextMeshProUGUI>().color = new Color(0, 141, 255);



        }

        SaveData();
    }

    private void TheEnd()
    {
        ChangeData();
        Time.timeScale = 0;
        EndMenu.gameObject.SetActive(true);


    }

    public void ChangeScene(string name)
    {
        Time.timeScale = 1;
        EndMenu.gameObject.SetActive(false);
        End = false;
        SceneManager.LoadScene(name);
      
    }

    private void SaveData()
    {
        using (var conn = new SqliteConnection(dbName))
        {
            conn.Open();


            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText = "INSERT INTO players_history (WinnerID,WinnerSprite,Name,P1Score,P2Score,Date) VALUES ( " + PlayerId + ", " + Winner + ", '" + (PlayerId == 1 ? P1Name : P2Name) + "', " + P1Score + ", " + P2Score +  ", '" + DateTime.UtcNow + "');";
                cmd.ExecuteNonQuery();
                
            }

            conn.Close();
        }
    }

    void Update()
    {

        if (End)
        {
            TheEnd();
            End = false;
        }
       
    }
}
