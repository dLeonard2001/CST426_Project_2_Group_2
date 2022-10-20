using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData 
{
    public int coins;


    public PlayerData(int coins)
    {
        this.coins = coins;
    }

    public static PlayerData CreateFromJSON(string jsonString)
    {
        return JsonUtility.FromJson<PlayerData>(jsonString);
    }
    
override 
    public string ToString()
    {
        return "Coins: " + coins+"\n";
    }
}
