using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

public class rotateCamera : MonoBehaviour
{
    public Animator cam_anim;
    public Animator panel_anim;
    public Animator control_panel_anim;
    
    private void Start()
    {
        cam_anim = GetComponent<Animator>();
    }

    // camera settings for showing character selection
        // position = vec3(0, -7.85, 0)
        // rotation = vec3(20, 0, 0)
        // spotlight intensity = 20
        // remove mainMenu panel

    public void startCharacterSelection()
    {

        cam_anim.SetTrigger("start");
        panel_anim.SetTrigger("off");
    }

    public void controlsOn()
    {
        StartCoroutine(switchToControlPanel());
    }

    public void controlsOff()
    {
        StartCoroutine(switchToMainMenuPanel());
    }
    
    public IEnumerator switchToMainMenuPanel()
    {
        control_panel_anim.SetTrigger("off");

        yield return new WaitForSeconds(1);
        
        panel_anim.SetTrigger("on");
    }

    public IEnumerator switchToControlPanel()
    {
        panel_anim.SetTrigger("off");

        yield return new WaitForSeconds(2.9f);
        
        control_panel_anim.SetTrigger("on");
    }
    
}
