using System.Collections.Generic;
using UnityEngine;

public static class Directions
{
    public static List<Vector3> eightDirections = new List<Vector3>(){
        new Vector3(0,0,1).normalized,
        new Vector3(1,0,0).normalized,
        new Vector3(1,0,1).normalized,
        new Vector3(1,0,-1).normalized,
        new Vector3(-1,0,1).normalized,
        new Vector3(-1,0,-1).normalized,
        new Vector3(0,0,-1).normalized,
        new Vector3(-1,0,0).normalized
    };
}
