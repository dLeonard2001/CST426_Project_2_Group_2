using UnityEngine;
using UnityEngine.SceneManagement;
public class EndPortalEvent : MonoBehaviour 
{
    bool hasTriggered;
    EndPortalEGrid epeg;
    SceneManager sceneManager;
    public float timer;
    Renderer renderer1, renderer2;

    void Start()
    {
        hasTriggered = false;
        epeg = transform.GetChild(1).GetComponent<EndPortalEGrid>();
        sceneManager = GetComponent<SceneManager>();
        renderer1 = GetComponent<Renderer>();
        renderer2 = transform.GetChild(0).GetComponent<Renderer>();
    }

    void Update()
    {
        timer = epeg.timer2;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // change it main menu for now.
            SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
        }

    }
}