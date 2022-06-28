using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;


public class GetTile : MonoBehaviour
{
    public List<Tilemap> walkables;
    public List<Tilemap> obstacles;

    public static GetTile instance;

    public GetTile()
    {
        instance = this;
    }
    public bool isObstacle(Vector2 position)
    {
        foreach (Tilemap tilemap in obstacles)
        {
            if (tilemap.GetTile(tilemap.WorldToCell(position)))
            {
                return true;
            }
            else
            {
                foreach (Tilemap walkable in walkables)
                {
                    if (walkable.GetTile(walkable.WorldToCell(position)))
                    {
                        return false;
                    }
                }
            }
        }
        return true;
    }
}
