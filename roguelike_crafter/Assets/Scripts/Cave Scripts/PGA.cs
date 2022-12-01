using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Direction
{
    public static List<Vector2Int> cardDirections = new List<Vector2Int>
    {
        new Vector2Int(0,1),
        new Vector2Int(1,0),
        new Vector2Int(0,-1),
        new Vector2Int(-1, 0)
    };

    public static Vector2Int getRandomDirection()
    {
        return cardDirections[Random.Range(0, cardDirections.Count)];
    }
}
public static class PGA 
{
    public static HashSet<Vector2Int> simpleRandomWalk(Vector2Int start, int walkTime)
    {
        HashSet<Vector2Int> path = new HashSet<Vector2Int>();
        path.Add(start);
        var prevPos = start;

        for (int c = 0; c < walkTime; c++)
        {
            var newPos = prevPos + Direction.getRandomDirection();
            path.Add(newPos);
            prevPos = newPos;
        }
        return path;
    }
}
