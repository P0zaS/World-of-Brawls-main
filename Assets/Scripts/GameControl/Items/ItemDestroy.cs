using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Controla cuando se destruyen los objetos de la partida
/// </summary>
public class ItemDestroy : MonoBehaviour
{

    private float timeToDestroy = 15;


    private void Start()
    {
        StartCoroutine(DestroyItem());
    }

    private IEnumerator DestroyItem()
    {
        yield return new WaitForSecondsRealtime(timeToDestroy);
        Destroy();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("Ground"))
        {
            Destroy();
        }
    }

    private void Destroy()
    {
        GameObject.Destroy(gameObject);
    }

    private void OnDestroy()
    {
        ItemSpawn.ItemsMax--;

    }
}
