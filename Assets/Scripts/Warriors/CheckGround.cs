using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Controla cuando el personaje esta tocando el suelo
/// </summary>
public class CheckGround : MonoBehaviour
{
    public static bool colPies;

    private void OnTriggerEnter2D(Collider2D collision)
    {        
         if (collision.gameObject.tag == "Ground") colPies = true;        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ground") colPies = false;
    }
}
