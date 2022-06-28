using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;

public class AlgorithmLee : PathFinder
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
        int generation = 0;
        while (waitingNodes.Count > 0)
        {
            List<Node> neibours = new List<Node>();
            for(int i = 0; i < waitingNodes.Count; i++)
            {
                if (waitingNodes[i].position != targetPosition) 
                {
                    if (waitingNodes[i].generation == generation + 1) {
                        if (!checkedNodes.Where(x => x.position == waitingNodes[i].position).Any())
                        {
                            checkedNodes.Add(waitingNodes[i]);
                            neibours.AddRange(GetNeighbourNodes(waitingNodes[i]));
                            waitingNodes.RemoveAt(i);
                            i--;
                        }
                        else
                        {
                            waitingNodes.RemoveAt(i);
                            i--;
                        } 
                    }
                }
                else
                {
                    return CreatePath(waitingNodes[i]);
                }
            }
            waitingNodes.AddRange(neibours);
            generation++;
        }
        return path;
    }
}
