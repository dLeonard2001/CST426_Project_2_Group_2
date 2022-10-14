using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapCreation : MonoBehaviour
{
   public int mapWidth, mapHeight, octaves, seed;
   public float noiseScale, lac;
   [Range(0, 1)]
   public float persis;
   public bool autoUpdate;
   public Vector2 manOffset;

   public void GenerateMap()
   {
       float [,] noiseMap = Noise.GenerateNoiseMap(mapWidth, mapHeight, noiseScale, octaves, persis, lac, seed, manOffset);
       MapDisplay display = FindObjectOfType<MapDisplay>();
       display.DrawNoiseMap(noiseMap);
   }

   void OnValidate()
   {
       if (mapWidth < 1)
       {
           mapWidth = 1;
       }

       if (mapHeight < 1)
       {
           mapHeight = 1;
       }

       if (octaves < 0)
       {
           octaves = 1;
       }

       if (lac < 1)
       {
           lac = 1;
       }
   }
}
