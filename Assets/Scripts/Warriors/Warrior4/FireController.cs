using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Controla cuando se destruye el fuego que genera el personaje 4
/// </summary>
public class FireController : MonoBehaviour
{
   
    public GameObject parent;   

    void Update()
    {
        StartCoroutine(DestroyItem());
    }

    IEnumerator DestroyItem()
    {
        yield return new WaitForSeconds(5f);
        GameObject.Destroy(parent);
    }
}
