using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Controla que pasa cuando se destruye un cartel
/// </summary>
public class CartelDestroy : MonoBehaviour
{
    public static float cooldownStun = 0.5f;

    private float lastHit = 0;
    private float dead = 0.5f;

    private Animator aCartel;

    private void Start()
    {
        aCartel = gameObject.GetComponent<Animator>();

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Ground") || collision.gameObject.tag.Contains("Player"))
        {
            lastHit = Time.time;
            aCartel.SetBool("isDestroyed", true);
        }
       

    }


    private void FixedUpdate()
    {
        if((Time.time - lastHit > dead) && aCartel.GetBool("isDestroyed"))
        {
            GameObject.Destroy(gameObject);

        }
    }

}
