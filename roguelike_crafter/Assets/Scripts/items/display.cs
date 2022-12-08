using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class display : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public int item_id;
    public Animator info_animator;
    public TextMeshProUGUI info_text;
    public TextMeshProUGUI item_count;
    private StringBuilder description;
    
    private void Awake()
    {
        description = new StringBuilder();
        info_animator = GetComponentInChildren<Animator>();
        info_text = GetComponentInChildren<TextMeshProUGUI>();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        info_animator.SetTrigger("on");
        //Debug.Log(description);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        info_animator.SetTrigger("off");
        // Debug.Log("leaving");
    }

    public void setDescription(string item_name, string d)
    {
        description.AppendLine(item_name);
        description.AppendLine();
        description.AppendLine(d);
        
        Debug.Log(description);

        info_text.SetText(description);
    }
}
