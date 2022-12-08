using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class loadScreen : MonoBehaviour
{
    public Animator sceneTransitionAnimation;

    public void loadCharacterSelection()
    {
        
    }

    public void startGame()
    {
        StartCoroutine(changeScene("MapLab"));
    }

    public void exitLevel()
    {
        Time.timeScale = 1;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.Confined;
        StartCoroutine(changeScene("MainMenu"));
    }

    public void quitGame()
    {
        Application.Quit();
    }

    private IEnumerator changeScene(string str)
    {
        sceneTransitionAnimation.SetTrigger("exit");

        yield return new WaitForSeconds(4f);
        
        // load next scene/level
        SceneManager.LoadScene(str);
    }
}
