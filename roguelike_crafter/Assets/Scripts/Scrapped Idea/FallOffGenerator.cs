using System;
using System.Reflection.Emit;
using System.Security.Cryptography;
using System.Drawing;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallOffGenerator
{
    public static float[,] GenerateFallO(Vector2Int size, float falloffStart, float falloffEnd)
    {
        float [,] heightMap = new float[size.x, size.y];
        for (int y = 0; y < size.y; y++)
        {
            for (int x = 0; x < size.x; x++)
            {
                Vector2 pos = new Vector2((float) x / size.x * 2 - 1, (float) y / size.y * 2 - 1);
                float t = Mathf.Max(Mathf.Abs(pos.x), Mathf.Abs(pos.y));

                if (t < falloffStart)
                {
                    heightMap[x, y] = 1;
                }
                else if (t > falloffEnd)
                {
                    heightMap[x, y] = 0;
                }
                else
                {
                    heightMap[x, y] = Mathf.SmoothStep(1, 0, Mathf.InverseLerp(falloffStart, falloffEnd, t));
                }
            }
        }
        return heightMap;
    }
}
