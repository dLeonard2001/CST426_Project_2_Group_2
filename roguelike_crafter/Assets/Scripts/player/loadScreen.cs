using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class loadScreen : MonoBehaviour
{
    public Animator sceneTransitionAnimation;

    public void loadGame()
    {
        StartCoroutine(changeScene());
    }

    private IEnumerator changeScene()
    {
        sceneTransitionAnimation.SetTrigger("exit");

        yield return new WaitForSeconds(2.5f);
        
        // load next scene/level
    }
}
