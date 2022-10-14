using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public static class MeshGen 
{
    public static MeshInfo GenerateTerrainMesh(float[,] heightMap)
    {
        int width = heightMap.GetLength(0);
        int height = heightMap.GetLength(1);
        MeshInfo meshInfo = new MeshInfo(width, height);
        int vertLocation = 0;
        float northWestX = (width - 1) / -2f;
        float northWestZ = (height - 1) / 2f;

        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                meshInfo.verts[vertLocation] = new Vector3(northWestX + x, heightMap[x, y], northWestZ - y);
                meshInfo.uvs[vertLocation] = new Vector2(x / (float) width, y / (float) height);
                if ( x < width - 1 && y < height - 1)
                {
                    meshInfo.AddTri(vertLocation, vertLocation + width + 1, vertLocation + width);
                    meshInfo.AddTri(vertLocation + width + 1, vertLocation, vertLocation + 1);

                }
                vertLocation++;
            }
        }
        return meshInfo;
    }
}

public class MeshInfo
{
    public Vector3[] verts;
    public int[] tris;
    public Vector2[] uvs;
    int triLocation;
    public MeshInfo(int meshW, int meshH)
    {
        verts = new Vector3[meshW * meshH];
        tris = new int[(meshW - 1) * (meshH - 1) * 6];
        uvs = new Vector2[meshW * meshH];
    }

    public void AddTri(int a, int b, int c)
    {
        tris[triLocation] = a;
        tris[triLocation + 1] = b;
        tris[triLocation + 2] = c;
        triLocation += 3;
    }

    public Mesh CreateMesh()
    {
        Mesh mesh = new Mesh();
        mesh.vertices = verts;
        mesh.triangles = tris;
        mesh.uv = uvs;
        mesh.RecalculateNormals();
        return mesh;
    }
}