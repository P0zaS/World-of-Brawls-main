using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/// <summary>
/// Se encarga de cambiar los mapas dependiendo de los seleccionado en la selección de mapa
/// </summary>
public class MapaManagement : MonoBehaviour
{
    public MapaDatabase mapaDB;

    public GameObject mapImage;

    private int selectedOption = 0;

    void Start()
    {

        selectedOption = 0;


        UpdateMapa(selectedOption);
    }

    public void OptionSelected(int number)
    {
        selectedOption = number;

        UpdateMapa(selectedOption);

    }

    private void UpdateMapa(int selectedOption)
    {
        Mapa mapa = mapaDB.GetMapa(selectedOption);

        mapImage.GetComponent<Image>().sprite = mapa.mapaSprite;
        Save();

    }



    private void Save()
    {       
      PlayerPrefs.SetInt("mapSelected", selectedOption);   
    }

    public void ChangeScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
