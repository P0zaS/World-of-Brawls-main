using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Clase que permite crear la base de datos de los personajes como un objeto
/// </summary>
[CreateAssetMenu]
public class CharacterDatabase : ScriptableObject
{
    public Character[] character;

    public int CharacterCount
    {
        get
        {
            return character.Length;
        }
    }

    public Character GetCharacter(int index)
    {
        return character[index];
    }
}
