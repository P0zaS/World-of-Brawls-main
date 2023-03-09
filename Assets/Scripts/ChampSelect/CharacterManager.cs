using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/// <summary>
/// Controla la selección de personaje de la escena ChampSelectScene
/// </summary>
public class CharacterManager : MonoBehaviour
{
    public CharacterDatabase characterDB;

    public GameObject p1NameText, p2NameText;
    public GameObject p1PlayerName, p2PlayerName;
    public GameObject p1Image, p2Image;

    private int selectedOption = 0;
    private int selectedOptionP1 = 0, selectedOptionP2 = 0;
    private bool p1HasSelected = false, p2HasSelected = false;
    void Start()
    {
        p1PlayerName.GetComponent<TMPro.TextMeshProUGUI>().text = PlayerPrefs.GetString("P1Name");
        p2PlayerName.GetComponent<TMPro.TextMeshProUGUI>().text = PlayerPrefs.GetString("P2Name");
        selectedOption = 0;


        UpdateCharacter(selectedOption);
    }

    public void OptionSelected(int number)
    {
        selectedOption = number;

        UpdateCharacter(selectedOption);

    }

    public void ConfirmSelection()
    {

        if (p1HasSelected)
        {
            p2HasSelected = true;
            Save(2);
        }
        else
        {
            p1HasSelected = true;
            Save(1);

        }
        DisableButtonOnSelect();

        StartGameWhenPlayersReady();
    }

    private void UpdateCharacter(int selectedOption)
    {
        Character character = characterDB.GetCharacter(selectedOption);

        if (p1HasSelected)
        {
            p2Image.GetComponent<Image>().sprite = character.characterSprite;
            p2NameText.GetComponent<TMPro.TextMeshProUGUI>().text = character.characterName;
        }
        else
        {
            p1Image.GetComponent<Image>().sprite = character.characterSprite;
            p1NameText.GetComponent<TMPro.TextMeshProUGUI>().text = character.characterName;
        }

    }

    private void StartGameWhenPlayersReady()
    {
        if (p1HasSelected && p2HasSelected)
        {
            ChangeScene("MapSelectScene");
        }
    }

    private void Save(int playerNumber)
    {
        if (playerNumber == 1)
        {
            selectedOptionP1 = selectedOption;
            PlayerPrefs.SetInt("selectedOptionP1", selectedOptionP1);
        }

        if (playerNumber == 2)
        {
            selectedOptionP2 = selectedOption;
            PlayerPrefs.SetInt("selectedOptionP2", selectedOptionP2);
        }


    }

    private void DisableButtonOnSelect()
    {
        
        if(selectedOptionP1 == 0)
        {

            GameObject.Find("Button1").GetComponent<Button>().interactable = false; 
        }
        else if (selectedOptionP1 == 1)
        {
            GameObject.Find("Button2").GetComponent<Button>().interactable = false; 

        }
        else if (selectedOptionP1 == 2)
        {

            GameObject.Find("Button3").GetComponent<Button>().interactable = false; 

        }
        else if (selectedOptionP1 == 3)
        {

            GameObject.Find("Button4").GetComponent<Button>().interactable = false; 

        }
    }

    public void ChangeScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }


}
