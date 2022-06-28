using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node 
{
    public Vector2 targetPosition { get; private set; }
    public Vector2 position { get; private set; }
    public int cost { get; private set; }
    public int generation { get; private set; }
    public Node previousNode;
    private int remoteDistance;
    private int distanceToTarget;

    private Node(Vector2 position)
    {
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
