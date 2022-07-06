using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using Models;

namespace Algoritms
{
    public class AStar : PathFinder
    {
        public override List<Vector2> GetNodeList(Vector2 position, Vector2 target)
        {
            ResetLists();
            Vector2 startPosition = new Vector2(Mathf.Round(position.x), Mathf.Round(position.y));
            Vector2 targetPosition = new Vector2(Mathf.Round(target.x), Mathf.Round(target.y));

            Node node = new Node(startPosition, targetPosition);
            BinaryTree tree = new BinaryTree();
            Queue<Node> waitings = new Queue<Node>();
            waitings.Enqueue(node);
            while (waitings.Count > 0)
            {
                Node nextNode = waitings.Where(node => node.cost == waitings.Min(node => node.cost)).FirstOrDefault();
                if (nextNode.position == targetPosition)
                {
                    return CreatePath(nextNode);
                }
                List<Node> nodes = GetNeighbourNodes(waitings.Dequeue());
                foreach (Node curNode in nodes)
                {
                    BinaryTree findedNode = tree.Find(curNode.ID);
                    if (findedNode == null)
                    {
                        waitings.Enqueue(curNode);
                        tree.Insert(curNode.ID);
                    }
                }
            }
            return path;
        }
    }
}