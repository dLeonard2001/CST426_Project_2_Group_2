using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

public class display : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private string description;
    
    public void OnPointerEnter(PointerEventData eventData)
    {
        Debug.Log(description);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Debug.Log("leaving");
    }

    public void setDescription(string d)
    {
        description = d;
    }
}
