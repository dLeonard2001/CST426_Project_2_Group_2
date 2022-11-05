using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class item_id : MonoBehaviour
{
    public Sprite item_image;
    public int id;
    [Tooltip("0 = Health \n" +
             "1 = base damage \n" +
             "2 = attack speed \n" +
             "3 = crit chance \n" +
             "4 = crit damage \n" +
             "5 = movement speed \n" +
             "6 = armor \n" +
             "7 = luck \n" +
             "8 = jump")] public int statToChange;
    public float statToAdd;
    public string description;
}
