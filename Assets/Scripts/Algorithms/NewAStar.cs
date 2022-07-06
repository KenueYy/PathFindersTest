using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System.Diagnostics;

public class NewAStar : PathFinder
{
    public override List<Vector2> GetNodeList(Vector2 position, Vector2  target)
    {
        Stopwatch stopwatch = new Stopwatch();
        stopwatch.Start();
        Vector2 startPosition = new Vector2(Mathf.Round(position.x), Mathf.Round(position.y));
        Vector2 targetPosition = new Vector2(Mathf.Round(target.x), Mathf.Round(target.y));

        Node node = new Node(startPosition, targetPosition);
        BinaryTree tree = new BinaryTree();
        Queue<Node> waitings = new Queue<Node>();
        Dictionary<Vector2, Node> visited = new Dictionary<Vector2, Node>();
        waitings.Enqueue(node);
        while (waitings.Count > 0)
        {
            Node nextNode = waitings.Where(node => node.cost == waitings.Min(node => node.cost)).FirstOrDefault();
            if (nextNode.position == targetPosition)
            {
                stopwatch.Stop();
                UnityEngine.Debug.Log(stopwatch.ElapsedMilliseconds);
                return CreatePath(nextNode);
            }
            List<Node> nodes = GetNeighbourNodes(waitings.Dequeue());
            foreach (Node curNode in nodes)
            {
                BinaryTree findedNode = tree.Find(curNode.ID);
                if (findedNode == null)
                {
                    waitings.Enqueue(curNode);
                    visited.Add(curNode.position, curNode);
                    tree.Insert(curNode.ID);
                }
            }
        }
        stopwatch.Stop();
        UnityEngine.Debug.Log(stopwatch.ElapsedMilliseconds);
        return path;
    }
}
