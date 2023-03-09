using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Base de datos de los carteles del mapa 2
/// </summary>
[CreateAssetMenu]
public class CartelDatabase : ScriptableObject
{
    public Cartel[] cartel;

    public int CharacterCount
    {
        get
        {
            return cartel.Length;
        }
    }

    public Cartel GetCartel(int index)
    {
        return cartel[index];
    }
}