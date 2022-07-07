using System.Collections.Generic;
using UnityEngine;
using Models;

namespace Algoritms
{
    public class AlgorithmLee : PathFinder
    {
        public override List<Vector2> GetNodeList(Vector2Int startPosition, Vector2Int targetPosition)
        {
            ResetLists();

            if (startPosition == targetPosition) return path;

            var targetId = GetTile.instance.GetNodeId(in targetPosition);

            Node startNode = new Node(startPosition, targetPosition);
            Queue<Node> waitings = new Queue<Node>();
            
            // Даже если не выводить это ID ячейки, то выставлять в качестве ключа Vector2 - плохая идея
            // Потому что при сравнении он будет сравнивать 2 флоата с другими 2мя флотатами
            // На точность этой операции не стоит возлагать надежды (не говоря о том, что это не обычный знак ==)
            // Dictionary<Vector2, Node> visited = new Dictionary<Vector2, Node>();
            Dictionary<long, Node> visited = new Dictionary<long, Node>();

            waitings.Enqueue(startNode);
            while (waitings.Count > 0)
            {
                // Здесь использовано именно перечисление, дабы не выделять под массив новой памяти
                // О прелестях работы с IEnumerable читай в документации
                IEnumerable<Node> nodes = GetNeighbourNodes(waitings.Dequeue());
                foreach (Node curNode in nodes)
                {
                    if (!visited.ContainsKey(curNode.ID))
                    {
                        if (curNode.ID != targetId)
                        {
                            waitings.Enqueue(curNode);
                            visited.Add(curNode.ID, curNode);
                        }
                        else
                        {
                            return CreatePath(curNode);
                        }
                    }
                }
            }
            return path;
        }
    }
}
