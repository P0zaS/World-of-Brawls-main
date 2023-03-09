using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BotonesControl : MonoBehaviour
{
    private void FixedUpdate()
    {
        foreach (Transform child in transform)
        {
            if (child.gameObject.GetComponent<Button>().navigation.selectOnUp)
            {
            }
            

        }
    }
}
