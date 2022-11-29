using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
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

        yield return new WaitForSeconds(4f);
        
        // load next scene/level
        SceneManager.LoadScene("MapLab");
    }
}
