using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class AStar : PathFinder
{
    public override List<Vector2> GetNodeList(Vector2 position, Vector2 target)
    {
        ResetLists();
        Vector2 startPosition = new Vector2(Mathf.Round(position.x), Mathf.Round(position.y));
        Vector2 targetPosition = new Vector2(Mathf.Round(target.x), Mathf.Round(target.y));

        if (startPosition == targetPosition) return path;

        Node startNode = new Node(startPosition, targetPosition);

        checkedNodes.Add(startNode);
        waitingNodes.AddRange(GetNeighbourNodes(startNode));
          
        while (waitingNodes.Count > 0)
        {
            Node nextNode = waitingNodes.Where(node => node.cost == waitingNodes.Min(node => node.cost)).FirstOrDefault();
            if (nextNode.position == targetPosition)
            {
                return CreatePath(nextNode);
            }
            waitingNodes.Remove(nextNode);
            if (!checkedNodes.Where(x => x.position == nextNode.position).Any())
            {
                checkedNodes.Add(nextNode);
                waitingNodes.AddRange(GetNeighbourNodes(nextNode));
            }
        }
        return path;
    }
}