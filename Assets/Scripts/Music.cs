using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Controla que la música no se reinicie entre escena y escena
/// </summary>
public class Music : MonoBehaviour
{

    private void Awake()
    {
        GameObject[] musicObj = GameObject.FindGameObjectsWithTag("Music");
        if(musicObj.Length > 1)
        {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(this.gameObject);
    }
    
}