using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class dataManager : MonoBehaviour
{
    private GameObject test;
    public int coins;
    public int level;
    public int atk;
    public float crit_chance;
    public float crit_multiplyer;
    public int num_gears;
    // Start is called before the first frame update
    void Start()
    {   
        
        //loadData();
        saveData();
        
    }



    void loadData()
    {
        string data = System.IO.File.ReadAllText(Application.persistentDataPath + "/Data.json");
        PlayerData pd = PlayerData.CreateFromJSON(data);
        Debug.Log("Load Successful");
        coins = pd.coins;
        level = pd.level;
        atk = pd.atk;
        crit_chance = pd.crit_chance;
        crit_multiplyer = pd.crit_multiplyer;
        num_gears = pd.num_gears;

        Debug.Log("Coins: " + coins +
                  "\nLevel: " + level +
                  "\nAttack Power: " + atk +
                  "\nCritical Hit Chance: " + crit_chance
                  + "\nCritical Hit Multiplyer: " + crit_multiplyer +
                  "\nNumber of Gears: " + num_gears);
    }

    void saveData()
    {
        //get data from player object
        PlayerData tpd = TestPlayerManager.getPlayerData();
        print(tpd);
        coins = tpd.coins; 
        level = tpd.level;
        atk = tpd.atk;
        crit_chance = tpd.crit_chance;
        crit_multiplyer = tpd.crit_multiplyer;
        num_gears = tpd.num_gears;
        string data = JsonUtility.ToJson(this);

        System.IO.File.WriteAllText(Application.persistentDataPath + "/Data.json", data);
        Debug.Log("Save Successful");

    }
}
