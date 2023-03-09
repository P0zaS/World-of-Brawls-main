using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

/// <summary>
/// Se encarga de inicializar los datos necesarios para generar la partida
/// </summary>
public class StartGame : MonoBehaviour
{
    public CharacterDatabase characterDB;
    public MapaDatabase mapaDB;
    public HealthBarScript healthBarP1;
    public HealthBarScript healthBarP2;
    public GameObject P1Name;
    public GameObject P2Name;

    private int player1Selection = 0, player2Selection = 0;
    private int mapaSelection = 0;
    private GameObject player1;
    private GameObject player2;
    void Start()
    {

        P1Name.GetComponent<TMPro.TextMeshProUGUI>().text = PlayerPrefs.GetString("P1Name");
        P2Name.GetComponent<TMPro.TextMeshProUGUI>().text = PlayerPrefs.GetString("P2Name");

        if (!PlayerPrefs.HasKey("selectedOptionP1") || !PlayerPrefs.HasKey("selectedOptionP2"))
        {
            player1Selection = 0;
            player2Selection = 1;
        }
        else
        {
            Load();
        }

        UpdateMapa();

        UpdateCharacter(1);
        UpdateCharacter(2);
    }

    
    private void UpdateCharacter(int playerNumber)
    {
       

        if(playerNumber == 1)
        {
            Character character = characterDB.GetCharacter(player1Selection);
            player1 = GameObject.Instantiate(character.character);
            if(player1Selection == 0)
            {
                player1.GetComponent<Warrior1>().healthBar = healthBarP1;
                player1.GetComponent<Warrior1>().Player = 1;
                player1.GetComponent<Warrior1>().Player1 = player1Selection;
                player1.GetComponent<Warrior1>().Player2 = player2Selection;
                player1.GetComponent<Transform>().position = new Vector3(-70, 40, 0);
         
            }
            else if(player1Selection == 1)
            {
                player1.GetComponent<Warrior2>().healthBar = healthBarP1;
                player1.GetComponent<Warrior2>().Player = 1;
                player1.GetComponent<Warrior2>().Player1 = player1Selection;
                player1.GetComponent<Warrior2>().Player2 = player2Selection;
                player1.GetComponent<Transform>().position = new Vector3(-70, 40, 0);
               
            }
            else if (player1Selection == 2)
            {
                player1.GetComponent<Warrior3>().healthBar = healthBarP1;
                player1.GetComponent<Warrior3>().Player = 1;
                player1.GetComponent<Warrior3>().Player1 = player1Selection;
                player1.GetComponent<Warrior3>().Player2 = player2Selection;
                player1.GetComponent<Transform>().position = new Vector3(-70, 40, 0);
               
            }
            else if (player1Selection == 3)
            {
                player1.GetComponent<Warrior4>().healthBar = healthBarP1;
                player1.GetComponent<Warrior4>().Player = 1;
                player1.GetComponent<Warrior4>().Player1 = player1Selection;
                player1.GetComponent<Warrior4>().Player2 = player2Selection;
                player1.GetComponent<Transform>().position = new Vector3(-70, 40, 0);
               
            }

           

        }
        else if(playerNumber == 2)
        {
            Character character = characterDB.GetCharacter(player2Selection);
            player2 = GameObject.Instantiate(character.character);
            if (player2Selection == 0)
            {
                player2.GetComponent<Warrior1>().healthBar = healthBarP2;
                player2.GetComponent<Warrior1>().Player = 2;
                player2.GetComponent<Warrior1>().Player1 = player1Selection;
                player2.GetComponent<Warrior1>().Player2 = player2Selection;
                player2.GetComponent<Transform>().position = new Vector3(70, 40, 0);
                
            }
            else if (player2Selection == 1)
            {
                player2.GetComponent<Warrior2>().healthBar = healthBarP2;
                player2.GetComponent<Warrior2>().Player = 2;
                player2.GetComponent<Warrior2>().Player1 = player1Selection;
                player2.GetComponent<Warrior2>().Player2 = player2Selection;
                player2.GetComponent<Transform>().position = new Vector3(70, 40, 0);
               
            }
            else if (player2Selection == 2)
            {
                player2.GetComponent<Warrior3>().healthBar = healthBarP2;
                player2.GetComponent<Warrior3>().Player = 2;
                player2.GetComponent<Warrior3>().Player1 = player1Selection;
                player2.GetComponent<Warrior3>().Player2 = player2Selection;
                player2.GetComponent<Transform>().position = new Vector3(70, 40, 0);
               
            }
            else if (player2Selection == 3)
            {
                player2.GetComponent<Warrior4>().healthBar = healthBarP2;
                player2.GetComponent<Warrior4>().Player = 2;
                player2.GetComponent<Warrior4>().Player1 = player1Selection;
                player2.GetComponent<Warrior4>().Player2 = player2Selection;
                player2.GetComponent<Transform>().position = new Vector3(70, 40, 0);
               
            }


        }



    }

    private void UpdateMapa()
    {
        Mapa mapa = mapaDB.GetMapa(mapaSelection);
        GameObject mapaCreated = GameObject.Instantiate(mapa.mapaGameObject);
    }

    private void Load()
    {
        player1Selection = PlayerPrefs.GetInt("selectedOptionP1");
        player2Selection = PlayerPrefs.GetInt("selectedOptionP2");
        mapaSelection = PlayerPrefs.GetInt("mapSelected");
    }

   

    
}
