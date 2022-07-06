using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Diagnostics;

public class PsevdoLee : PathFinder
{
    public override List<Vector2> GetNodeList(Vector2 position, Vector2 target)
    {
        Stopwatch stopwatch = new Stopwatch();
        stopwatch.Start();
        ResetLists();
        Vector2 startPosition = new Vector2(Mathf.Round(position.x), Mathf.Round(position.y));
        Vector2 targetPosition = new Vector2(Mathf.Round(target.x), Mathf.Round(target.y));

        if (startPosition == targetPosition) return path;

        Node startNode = new Node(startPosition, targetPosition);
        Queue<Node> waitings = new Queue<Node>();
        //BinaryTree tree = new BinaryTree();
        Dictionary<Vector2, Node> visited = new Dictionary<Vector2, Node>();
        waitings.Enqueue(startNode);
        while(waitings.Count > 0)
        {
            List<Node> nodes = GetNeighbourNodes(waitings.Dequeue());
            foreach (Node curNode in nodes)
            {
                //BinaryTree findedNode = tree.Find(curNode.ID);
                //if (findedNode == null)
                //{
                if (!visited.ContainsKey(curNode.position))
                {
                    if(curNode.position != targetPosition)
                    {
                        waitings.Enqueue(curNode);
                        visited.Add(curNode.position, curNode);
                        //tree.Insert(curNode.ID);
                    }
                    else
                    {
                       
                        stopwatch.Stop();
                        UnityEngine.Debug.Log(stopwatch.ElapsedMilliseconds);
                        return CreatePath(curNode);
                    }
                }
            }
        }
        return path;
    }
}
