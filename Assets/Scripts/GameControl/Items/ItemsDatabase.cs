
using UnityEngine;

/// <summary>
/// La base de datos para almacenar los objetos de la partida
/// </summary>
[CreateAssetMenu]
public class ItemsDatabase : ScriptableObject
{
    public Item[] item;

    public int ItemCount
    {
        get
        {
            return item.Length;
        }
    }

    public Item GetItem(int index)
    {
        return item[index];
    }
}