using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//DO NOT CHANGE THIS
[System.Serializable]
public class PlayerData 
{
    public int coins;
	public int level;
	public int atk;
	public float crit_chance;
	public float crit_multiplyer;
	public int num_gears; //Upgrade items
	
	 
	public PlayerData(){
		this.coins = 0;
		this.level = 1;
		this.atk = 10;
		this.crit_chance = 0.05f;
		this.crit_multiplyer = 2.0f;
		this.num_gears = 0;
	}

    public PlayerData(int coins, int lvl, int atk, float crit_chance,
						float crit_mul, int num_gears)
    {
        this.coins = coins;
		this.level = lvl;
		this. atk = atk;
		this.crit_chance = crit_chance;
		this.crit_multiplyer = crit_mul;
		this.num_gears = num_gears;
    }

    public static PlayerData CreateFromJSON(string jsonString)
    {
        return JsonUtility.FromJson<PlayerData>(jsonString);
    }
    
override 
    public string ToString()
    {
        return "Coins: " + coins +
                  "\nLevel: " + level +
                  "\nAttack Power: " + atk +
                  "\nCritical Hit Chance: " + crit_chance
                  + "\nCritical Hit Multiplyer: " + crit_multiplyer +
                  "\nNumber of Gears: " + num_gears;
    }
}
