using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Modifica la posición de las plataformas del mapa 3 cuando llegan a su limite 
/// </summary>
public class RespawnPlatforms : MonoBehaviour
{
    
    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        collision.transform.position = new Vector3(collision.transform.position.x - 500, collision.transform.position.y, 0);

    }
}
