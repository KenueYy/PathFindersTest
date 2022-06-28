using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class View : MonoBehaviour, IView
{
    private List<Vector2> path;
    private Vector2 firstPoint;
    private Vector2 secondPoint;
    void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawSphere(firstPoint + new Vector2(0.5f, 0.5f), 0.3f);
        Gizmos.DrawSphere(secondPoint + new Vector2(0.5f, 0.5f), 0.3f);
        if (path != null)
            foreach (var item in path)
            {
                Gizmos.color = Color.red;
                Gizmos.DrawSphere(new Vector2(item.x + 0.5f, item.y + 0.5f), 0.1f);
            }
    }
    public void SetPath(List<Vector2> path)
    {
        this.path = path;
    }
    public void SetFirstPoint(Vector2 position)
    {
        if (!GetTile.instance.isObstacle(position))
            firstPoint = new Vector2(Mathf.Round(position.x), Mathf.Round(position.y));
        else
            Debug.Log(Exceptions.Exception.NodeIsNotWalkable);
    }
    public void SetSecondPoint(Vector2 position)
    {
        if (!GetTile.instance.isObstacle(position))
            secondPoint = new Vector2(Mathf.Round(position.x), Mathf.Round(position.y));
        else
            Debug.Log(Exceptions.Exception.NodeIsNotWalkable);
    }
}
