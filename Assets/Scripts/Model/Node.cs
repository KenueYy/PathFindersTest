using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node
{
    public long ID { get; private set; }
    public Vector2 targetPosition { get; private set; }
    public Vector2 position { get; private set; }
    public int generation { get; private set; } //для первого варианта Ли

    public Node previousNode;
    public int cost { get; private set; } // для A*
    private int remoteDistance;
    private int distanceToTarget;

    private Node(Vector2 position)
    {
        this.ID = int.Parse((Mathf.Abs(GetTile.instance.MinX()) + (int)position.x).ToString() + 
                            (Mathf.Abs(GetTile.instance.MinY()) + (int)position.y).ToString());
        this.position = position;
    }
    public Node(Vector2 position, Vector2 targetPosition) : this(position)
    {
        this.targetPosition = targetPosition;
    }
    public Node(Vector2 position, Node previousNode) : this(position)
    {
        this.previousNode = previousNode;

        generation = previousNode.generation + 1;
        targetPosition = previousNode.targetPosition;
        remoteDistance = previousNode.remoteDistance + 1;
        distanceToTarget = Mathf.RoundToInt(Mathf.Abs(targetPosition.x - position.x) + Mathf.Abs(targetPosition.y - position.y));
        cost = remoteDistance + distanceToTarget;
    }
}
