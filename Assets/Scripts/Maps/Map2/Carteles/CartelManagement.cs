using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Se encarga de generar los carteles de manera aleatoria
/// </summary>
public class CartelManagement : MonoBehaviour
{
    public CartelDatabase cartelDB;
    public float cooldown;

    private int selectedOption = 0;
    private float lastItemCreated = 0;

    void Update()
    {
        if(Time.time - lastItemCreated > cooldown)
        {
            selectedOption = Random.Range(0, 4);
            UpdateCharacter(selectedOption);
        }
        
    }

    private void UpdateCharacter(int selectedOption)
    {
        Cartel cartel = cartelDB.GetCartel(selectedOption);

        GameObject cartelCreated = GameObject.Instantiate(cartel.CartelObject);
        cartelCreated.transform.position = new Vector3(Random.Range(-143.7f, 156f), 200f, 0);
        lastItemCreated = Time.time;    
    }
}
