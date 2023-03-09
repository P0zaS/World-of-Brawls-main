using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Contiene los metodos que controlan la barra de vida, su vida maxima y cuando ganan rondas los jugadores
/// </summary>
public class HealthBarScript : MonoBehaviour
{
    public Slider slider;
    public GameObject punto1;
    public GameObject punto2;

    public void SetMaxHealth(int hp)
    {
        slider.maxValue = hp;
        slider.value = hp;
    }

    public void SetHealth(int hp)
    {
        slider.value = hp;
    }

    public void SetWin()
    {
        Color p1 = punto1.GetComponent<Image>().color;
        if(p1 == new Color(255, 255, 255, 100))
        {
            punto2.GetComponent<Image>().color = new Color(255, 255, 255, 100);
        }
        else
        {
            punto1.GetComponent<Image>().color = new Color(255, 255, 255, 100);
        }


    }
    public void ResetPoints()
    {
        punto1.GetComponent<Image>().color = new Color(255,255,255,91);
        punto2.GetComponent<Image>().color = new Color(255,255,255,91);
    }

}
