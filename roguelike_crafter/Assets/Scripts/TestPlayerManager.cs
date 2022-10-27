using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestPlayerManager : MonoBehaviour
{
    private static PlayerData pd;
    // Start is called before the first frame update
    
    void Start()
    {
        pd = new PlayerData(57, 12, 3, 0.05f, 1.95f, 45);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public static PlayerData getPlayerData() {
        return pd;
    }
}
