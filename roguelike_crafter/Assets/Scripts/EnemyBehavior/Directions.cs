using System.Collections.Generic;
using UnityEngine;

public static class Directions
{
    public static List<Vector3> eightDirections = new List<Vector3>(){
        new Vector3(1,0,0).normalized,//right
        new Vector3(1,0,1).normalized,//forward - right
        new Vector3(0,0,1).normalized,//forward
        new Vector3(-1,0,1).normalized,//forward - left 
        new Vector3(-1,0,0).normalized,//left
        new Vector3(-1,0,-1).normalized,//back, left
        new Vector3(0,0,-1).normalized,//back
        new Vector3(1,0,-1).normalized//back - right
    };
}
