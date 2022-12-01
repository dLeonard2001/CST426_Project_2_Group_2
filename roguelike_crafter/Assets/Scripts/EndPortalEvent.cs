using UnityEngine;
using UnityEngine.SceneManagement;
public class EndPortalEvent : MonoBehaviour 
{
    bool hasTriggered;
    EndPortalEGrid epeg;
    SceneManager sceneManager;

    void Start()
    {
        hasTriggered = false;
        epeg = transform.GetChild(1).GetComponent<EndPortalEGrid>();
        sceneManager = GetComponent<SceneManager>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (!hasTriggered)
        {
            epeg.startEvent();
            hasTriggered = true;
        }
        
        else if (hasTriggered && !epeg.triggerEnd)
        {
            // change it main menu for now.
            //SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
        }
    }
}