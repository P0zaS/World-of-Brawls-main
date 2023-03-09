using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

/// <summary>
/// Clase que selecciona el objeto que la contiene al pasar el rat�n por encima
/// </summary>
public class AutoSelect : MonoBehaviour, IPointerEnterHandler
{
    [SerializeField]
    private Selectable selectable = null;

    public void OnPointerEnter(PointerEventData eventData)
    {
        selectable.Select();
    }

   

}
