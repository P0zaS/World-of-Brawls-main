using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Controla cuando el personaje recibe mas daño
/// </summary>
public class IsWeakControl : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        WarriorsController.IsWeak = false;

        if (collision.gameObject.tag.Contains("Attack"))
        {
            WarriorsController.IsWeak = true;
        }

        if (collision.gameObject.tag.Contains("Arrow"))
        {
            WarriorsController.IsWeak = true;
        }

        if (collision.gameObject.tag.Contains("FireBall"))
        {
            WarriorsController.IsWeak = true;
        }
    }
    
   

    
   

}
