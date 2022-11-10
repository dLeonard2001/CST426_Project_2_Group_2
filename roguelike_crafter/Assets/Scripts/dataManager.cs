using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class dataManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        loadData();
        //saveData();
    }



    void loadData()
    {
        string data = System.IO.File.ReadAllText(Application.persistentDataPath + "/Data.json");
        Debug.Log("Encoded data:"+data);
        data = decodeData(data);
        Debug.Log("Decoded data:"+data);
        PlayerData pd = PlayerData.CreateFromJSON(data);
        Debug.Log("Load Successful");
        
        TestPlayerManager.setPlayerData(pd);
        
        
    }

    void saveData()
    {
        //get data from player object
        PlayerData tpd = TestPlayerManager.getPlayerData();
        string data = JsonUtility.ToJson(tpd);
        data = encodeData(data);
        System.IO.File.WriteAllText(Application.persistentDataPath + "/Data.json", data);
        Debug.Log("Save Successful");

    }

    string encodeData(string data)
    {
        string output="";
        int asciiVal;
        int encodeNum;
        for (int i = 0; i < data.Length; i++)
        {
            asciiVal = (int)data[i];
            encodeNum = (2*asciiVal) - 5;
            output += encodeNum.ToString()+"\n";
        }
        return output;
    }

    string decodeData(string data)
    {
        string output = "";
        int asciiValue = 48;
        
        for (int i = 0; i < data.Length; i++)
        {
            string currChar = "";
            int j = i;
            while (data[j]!='\n')
            {
                currChar += data[j];
                j++;
            }

            i = j;
            print("Current char: "+(char)((int.Parse(currChar)+5)/2));
            asciiValue = (int.Parse(currChar)+ 5) / 2;
            output += (char)asciiValue;
        }
        print(output);
        return output;
    }

}
