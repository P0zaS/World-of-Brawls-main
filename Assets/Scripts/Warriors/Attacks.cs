using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Controla el empuje que recibe el cartel al recibir un ataque
/// </summary>
public class Attacks : MonoBehaviour
{
    public GameObject parent;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Cartel"))
        {
            Rigidbody2D rigidbody = collision.gameObject.GetComponent<Rigidbody2D>();
            if(parent.transform.localScale.x > 0)
            {
                rigidbody.AddForce(new Vector2(rigidbody.mass * 10000 , rigidbody.mass), ForceMode2D.Force);

            }
            else
            {
                rigidbody.AddForce(new Vector2(rigidbody.mass * 10000 * -1, rigidbody.mass), ForceMode2D.Force);

            }


        }

     
    }

   
}
