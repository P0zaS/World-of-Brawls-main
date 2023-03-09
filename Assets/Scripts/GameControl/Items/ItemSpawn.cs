using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Controla el spawn de los objetos de la partida
/// </summary>
public class ItemSpawn : MonoBehaviour
{
    public ItemsDatabase itemDB;

    private float lastItemSpawn = 0;
    private float cooldown = 10;

    public static int ItemsMax = 0;

    private int MapCreated = 0;
    private void Start()
    {
        MapCreated = PlayerPrefs.GetInt("mapSelected");
    }
    void Update()
    {


        if((Time.time - lastItemSpawn > cooldown) && ItemsMax < 3)
        {
            lastItemSpawn = Time.time;
            CreateItem(Random.Range(0, 3));
        }
    }

    private void CreateItem(int selectedOption)
    {
        Item item = itemDB.GetItem(selectedOption);

        GameObject itemCreated = GameObject.Instantiate(item.item);

        if(MapCreated == 1)
        {
            itemCreated.transform.position = new Vector3(Random.Range(-170f, 70f), Random.Range(12f, 50f), 0);
        }
        else
        {
            itemCreated.transform.position = new Vector3(Random.Range(-170f, 70f), Random.Range(12f, 140f), 0);
        }

        ItemsMax++;
    }
}
