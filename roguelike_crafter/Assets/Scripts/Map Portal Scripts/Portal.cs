using UnityEngine;

public class Portal : MonoBehaviour 
{
    Transform exitLocal;
    [SerializeField] static float usedTimer;
    [SerializeField] static bool hasUsed;

    void Start() 
    {
        usedTimer = 0f;
        hasUsed = false;
        setExits();
    }

    void setExits()
    {
        Transform secondary;
        if (gameObject.tag.Equals("TPA"))
        {
            secondary = GameObject.FindGameObjectWithTag("TPB").transform.GetChild(0);
            exitLocal = secondary;
        }
        
        else 
        {
            secondary = GameObject.FindGameObjectWithTag("TPA").transform.GetChild(0);
            exitLocal = secondary;
        }
    }

    void OnTriggerEnter(Collider other)
    {
       if (other.CompareTag("Player") && !hasUsed)
       {
           var player = other.GetComponentInChildren<Player>();
           Portal secondary;
           if (gameObject.tag.Equals("TPA"))
           {
               secondary = GameObject.FindGameObjectWithTag("TPB").GetComponent<Portal>();
               player.Teleport(exitLocal.position, exitLocal.rotation);
           }

           else
           {
               secondary = GameObject.FindGameObjectWithTag("TPA").GetComponent<Portal>();
               player.Teleport(exitLocal.position, exitLocal.rotation);
           }
           hasUsed = true;
           usedTimer = 5f;
       }
    }

    void Update()
    {
        if (hasUsed)
        {
            if (usedTimer <= 0)
            {
                hasUsed = false;
            }

            else
            {
                usedTimer -= Time.deltaTime;
            }
        }
    }
}