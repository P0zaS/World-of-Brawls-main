using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Permite crear la base de datos de mapas
/// </summary>
[CreateAssetMenu]
public class MapaDatabase : ScriptableObject
{
    public Mapa[] mapa;

    public int MapCount
    {
        get
        {
            return mapa.Length;
        }
    }

    public Mapa GetMapa(int index)
    {
        return mapa[index];
    }
}
