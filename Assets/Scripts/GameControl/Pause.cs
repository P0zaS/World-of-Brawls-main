using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Controla el menú de pausa de la partida
/// </summary>
public class Pause : MonoBehaviour
{
    public GameObject PauseMenu;
    public static bool IsPaused;
    public void PauseGame()
    {
        Time.timeScale = 0;
        PauseMenu.gameObject.SetActive(true);


    }

    public void UnPauseGame()
    {
        Time.timeScale = 1;
        PauseMenu.gameObject.SetActive(false);
        IsPaused = false;
    }

    public void ChangeScene(string name)
    {
        SceneManager.LoadScene(name);
        UnPauseGame();
    }

    private void Update()
    {

        if (IsPaused)
        {
            PauseGame();
        }
       
    }
}
