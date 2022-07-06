using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PathFinder : MonoBehaviour
{
    protected List<Vector2> path = new List<Vector2>();
    protected List<Node> checkedNodes;
    protected List<Node> waitingNodes;

    protected List<Vector2> directions = new List<Vector2>();

    public PathFinder()
    {
        directions.Add(Vector2.up);
        directions.Add(Vector2.right);
        directions.Add(Vector2.down);
        directions.Add(Vector2.left);
    }
    public virtual List<Vector2> GetNodeList(Vector2 position, Vector2 target)
    {
        return path;
    }
    protected virtual void ResetLists()
    {
        path = new List<Vector2>();
        waitingNodes = new List<Node>();
        checkedNodes = new List<Node>();
    }
    protected virtual List<Node> GetNeighbourNodes(Node node)
    {
        List<Node> neighbours = new List<Node>();

        foreach (Vector2 direction in directions)
        {
            if (!GetTile.instance.isObstacle(node.position + direction))
            {
                Node neigbour = new Node(node.position + direction, node);
                neighbours.Add(neigbour);
            }
        }

        return neighbours;
    }
    protected virtual List<Vector2> CreatePath(Node node)
    {
        Node currentNode = node;

        while (currentNode.previousNode != null)
        {
            path.Add(new Vector2(currentNode.position.x, currentNode.position.y));
            currentNode = currentNode.previousNode;
        }

        return path;
    }
}
