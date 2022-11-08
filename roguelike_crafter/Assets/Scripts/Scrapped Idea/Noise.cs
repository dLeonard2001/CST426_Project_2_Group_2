using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Noise
{
    public static float[,] GenerateNoiseMap(int mapWidth, int mapHeight, float scale, int octaves, float persis, float lac, int seed, Vector2 manOffset)
    {
        System.Random rng = new System.Random(seed);
        Vector2[] octOffset = new Vector2[octaves];

        for (int thing = 0; thing < octaves; thing++)
        {
            float offsetX = rng.Next(-100000, 100000) + manOffset.x;
            float offsetY = rng.Next(-100000, 100000) + manOffset.y;
            octOffset[thing] = new Vector2(offsetX, offsetY);
        }

        if (scale <= 0)
        {
            scale = .0001f;
        }
        float maxNoiseHeight = float.MinValue;
        float minNoiseHeight = float.MaxValue;
        float[,] noiseMap = new float[mapWidth, mapHeight];

        float halfWidth = mapWidth / 2f;
        float halfHeight = mapHeight / 2f;
        for (int y = 0; y < mapHeight; y++)
        {
            for (int x = 0; x < mapWidth; x++)
            {
                float amplitude = 1f;
                float freq = 1f;
                float noiseHight = 0f;
                for (int o = 0 ; o < octaves; o++)
                {
                    float tempX = (x - halfWidth) / scale * freq + octOffset[o].x * freq;
                    float tempY = (y - halfHeight) / scale * freq - octOffset[o].y * freq;
                    float perlinVal = Mathf.PerlinNoise(tempX, tempY) * 2 - 1;
                    noiseHight +=  perlinVal * amplitude;
                    amplitude *= persis;
                    freq *= lac;
                }
                if (noiseHight > maxNoiseHeight)
                {
                    maxNoiseHeight = noiseHight;
                }
                else if (noiseHight < minNoiseHeight)
                {
                    minNoiseHeight = noiseHight;
                }
                noiseMap[x, y] = noiseHight;
            }
        }

        for (int y = 0; y < mapHeight; y++)
        {
            for (int x = 0; x < mapHeight; x++)
            {
                noiseMap[x,y] = Mathf.InverseLerp(minNoiseHeight, maxNoiseHeight, noiseMap[x,y]);
            }
        }
        return noiseMap;
    }
}
