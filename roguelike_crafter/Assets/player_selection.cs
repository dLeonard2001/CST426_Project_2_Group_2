using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class player_selection : MonoBehaviour
{
    public Animator player_anim;
    public Animator spotlight_anim;
    public GameObject spotLight;

    public UnityEvent start_event;
    private bool cr_active;

    // Start is called before the first frame update

    private void OnMouseEnter()
    {
        if (!cr_active)
        {
            spotlight_anim.SetTrigger("on");
            player_anim.SetTrigger("on");
        }
        
    }

    private void OnMouseExit()
    {
        if (!cr_active)
        {
            spotlight_anim.SetTrigger("off");
            player_anim.SetTrigger("off");
        }
    }

    private void OnMouseDown()
    {
        StartCoroutine(startGame());
    }

    private IEnumerator startGame()
    {
        cr_active = true;

        yield return new WaitForSeconds(1);
        
        start_event.Invoke();
    }
}
