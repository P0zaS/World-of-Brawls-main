using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Guarda los nombres de los jugadores en la selección de nombres 
/// </summary>
public class PlayerName : MonoBehaviour
{


    public GameObject P1Input;
    public GameObject P2Input;

    private void SavePlayersNames()
    {
      
        PlayerPrefs.SetString("P1Name", P1Input.GetComponent<TMPro.TextMeshProUGUI>().text ?? "P1");
        PlayerPrefs.SetString("P2Name", P2Input.GetComponent<TMPro.TextMeshProUGUI>().text ?? "P2");

    }

    public void Continue()
    {
        SavePlayersNames();
        CargarNivel("ChampSelectScene");
    }
    public void CargarNivel(string nombreScena)
    {
        SceneManager.LoadScene(nombreScena);
    }

    
}
