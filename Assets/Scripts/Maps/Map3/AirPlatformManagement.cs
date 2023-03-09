using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Se encarfa de controlar las plataformas del mapa 3, se establece como 
/// objeto padre de los objetos cuando entran en contacto con el hasta su salida
/// </summary>
public class AirPlatformManagement : MonoBehaviour
{

    

    public static float lastTimeHidden = 0;

    

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!collision.gameObject.tag.Equals("PlatformLimit") || !collision.gameObject.tag.Equals("Ground"))
        {
            MoveWithIn(collision, transform);
           
        }
        
    }

    

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (!collision.gameObject.tag.Equals("PlatformLimit") || !collision.gameObject.tag.Equals("Ground"))
        {
            MoveWithIn(collision, null);
            foreach (Transform child in transform)
            {
                child.gameObject.transform.SetParent(null);

            }
            gameObject.SetActive(false);
            lastTimeHidden = Time.time;
          

        }

    }

    

    private void MoveWithIn(Collision2D collision, Transform value)
    {
        collision.collider.transform.SetParent(value);
    }

    

}
