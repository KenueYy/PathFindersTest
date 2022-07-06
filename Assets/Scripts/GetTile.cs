using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;


public class GetTile : MonoBehaviour
{
    public List<Tilemap> walkables;
    public List<Tilemap> obstacles;

    public static GetTile instance;
    [SerializeField] private Vector2Int leftUpPoint;
    [SerializeField] private Vector2Int rightDownPoint;
    public GetTile()
    {
        instance = this;
    }
    public void Start()
    {
        //Normalize();
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
    public int MinX()
    {
        if (leftUpPoint.x > rightDownPoint.x)
            return rightDownPoint.x;
        else if (leftUpPoint.x < rightDownPoint.x)
            return leftUpPoint.x;
        else
            return leftUpPoint.x;
    }
    public int MinY()
    {
        if (leftUpPoint.y > rightDownPoint.y)
            return rightDownPoint.x;
        else if (leftUpPoint.y < rightDownPoint.y)
            return leftUpPoint.y;
        else
            return leftUpPoint.y;
    }
    //private void Normalize()
    //{
    //    leftUpPoint = new Vector2(Mathf.Round(leftUpPoint.x), Mathf.Round(leftUpPoint.y));
    //    rightDownPoint = new Vector2(Mathf.Round(rightDownPoint.x), Mathf.Round(rightDownPoint.y));
    //}
}
