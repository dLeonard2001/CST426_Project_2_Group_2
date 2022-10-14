using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapCreation : MonoBehaviour
{
    public enum DrawMode {NoiseMap, ColorMap, Mesh}; 
    public DrawMode drawMode;
   public int mapWidth, mapHeight, octaves, seed;
   public float noiseScale, lac;
   [Range(0, 1)]
   public float persis;
   public bool autoUpdate;
   public Vector2 manOffset;
   public GroundType[] groundColors;
   public void GenerateMap()
   {
       float [,] noiseMap = Noise.GenerateNoiseMap(mapWidth, mapHeight, noiseScale, octaves, persis, lac, seed, manOffset);
       Color[] colorMap = new Color[mapWidth * mapHeight];
       for (int y = 0; y < mapHeight; y++)
       {
           for (int x = 0; x < mapHeight; x++)
           {
               float currentHeight = noiseMap[x, y];
               for (int p = 0; p < groundColors.Length; p++)
               {
                   if (currentHeight <= groundColors[p].height)
                   {
                       colorMap[y * mapWidth + x] = groundColors[p].color;
                       break;
                   }
               }
           }
       }
       MapDisplay display = FindObjectOfType<MapDisplay>();
       if (drawMode == DrawMode.NoiseMap)
       {
           display.DrawTexture(TextGen.textureFromHM(noiseMap));
       }

       else if (drawMode == DrawMode.ColorMap)
       {
           display.DrawTexture(TextGen.textureFromCM(colorMap, mapWidth, mapHeight));
       }

       else if (drawMode == DrawMode.Mesh)
       {
           display.DrawMesh(MeshGen.GenerateTerrainMesh(noiseMap), TextGen.textureFromCM(colorMap, mapWidth, mapHeight));
       }
    //    display.DrawNoiseMap(noiseMap);
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

[System.Serializable]
   public struct GroundType 
   {
       public string name;
       public float height;
       public Color color;
   }
