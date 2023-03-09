using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Controla los limites del mapa 1 y permite aparecer al otro lado
/// </summary>
public class LimitRespawn : MonoBehaviour
{
    public bool isLeftLimit = false;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (isLeftLimit)
        {
            collision.gameObject.GetComponent<Transform>().position = new Vector3(collision.gameObject.GetComponent<Transform>().position.x + 320, collision.gameObject.GetComponent<Transform>().position.y, 0);
        }
        else
        {
            collision.gameObject.GetComponent<Transform>().position = new Vector3(collision.gameObject.GetComponent<Transform>().position.x - 320, collision.gameObject.GetComponent<Transform>().position.y, 0);
        }
        
    }
}
