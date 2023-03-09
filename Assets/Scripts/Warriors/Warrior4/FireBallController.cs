using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Controla lo que le pasa a la bola de fuego al impactar
/// </summary>
public class FireBallController : MonoBehaviour
{
    

    private void OnCollisionEnter2D(Collision2D collision)
    {


        if (collision.gameObject.tag.Equals("Cartel"))
        {
            Rigidbody2D rigidbody = collision.gameObject.GetComponent<Rigidbody2D>();

            if (gameObject.transform.rotation == new Quaternion(0, 1, 0, 0))
            {
                rigidbody.AddForce(new Vector2(rigidbody.mass * -1 * 8000, rigidbody.mass), ForceMode2D.Force);

            }
            if (gameObject.transform.rotation == new Quaternion(0, 0, 0, 1))
            {
                rigidbody.AddForce(new Vector2(rigidbody.mass * 8000, rigidbody.mass), ForceMode2D.Force);

            }


        }

        GameObject.Destroy(gameObject);


    }

}
