using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;


/// <summary>
/// se encarga de controlar el menu de incio, cambiando de escena y saliendo de la app
/// </summary>
public class MainMenu : MonoBehaviour
{
    public void CargarNivel(string nombreScena)
    {
        SceneManager.LoadScene(nombreScena);
    }

    public void Salir()
    {
        Application.Quit();
    }
}
