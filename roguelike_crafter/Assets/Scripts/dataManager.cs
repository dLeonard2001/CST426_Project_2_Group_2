using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class dataManager : MonoBehaviour
{
    public int coins;
    // Start is called before the first frame update
    void Start()
    {
        saveData();
        loadData();
    }



    void loadData()
    {
        string data = System.IO.File.ReadAllText(Application.persistentDataPath + "/Data.json");
        PlayerData pd2 = PlayerData.CreateFromJSON(data);
        Debug.Log(pd2);
        Debug.Log("Load Successful");
    }

    void saveData()
    {
        coins = 7;
        string data = JsonUtility.ToJson(this);

        System.IO.File.WriteAllText(Application.persistentDataPath + "/Data.json", data);
        Debug.Log("Save Successful");

    }
}
