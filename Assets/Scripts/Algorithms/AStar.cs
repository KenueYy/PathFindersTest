using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using Models;

namespace Algoritms
{
    public class AStar : PathFinder
    {
        public override List<Vector2> GetNodeList(Vector2Int startPosition, Vector2Int targetPosition)
        {
            ResetLists();

            var targetId = GetTile.instance.GetNodeId(targetPosition);

            Node node = new Node(startPosition, targetPosition);
            BinaryTree tree = new BinaryTree();
            
            Queue<Node> waitings = new Queue<Node>();
            
            waitings.Enqueue(node);
            while (waitings.Count > 0)
            {
                // 1. Все-таки настоятельно рекомендую почитать, как работают IEnumerable, потому что здесь ты
                //      сначала выбираешь все подходящие под Where элементы
                //      потом берешь первый попавшийся
                //      А можно сразу вернуть первый попавшийся
                Node nextNode = waitings.FirstOrDefault(x => x.cost == waitings.Min(xx => xx.cost));
                // 2. Во-вторых, задача быстрого извлечения минимального элемента решается либо при помощи минимальной двоичной кучи (оптимально)
                //      Либо при помощи бинарного дерева (за O(log(n)) операций в среднем)
                //Node nextNode = waitings.Where(node => node.cost == waitings.Min(node => node.cost)).FirstOrDefault();
                if (nextNode!.ID == targetId)
                {
                    return CreatePath(nextNode);
                }
                // ненененененене
                // Вообще ни в коем случае
                // По какой причине ты берешь следующий из очереди 'waitings.Dequeue()', а до этого работал с минимальным по стоимости?????
                // Вот здесь и причина, почему A* работает долго: потому что он работает, как волновой, только еще какую-то тонну лишний операций делает
                IEnumerable<Node> nodes = GetNeighbourNodes(waitings.Dequeue());
                foreach (Node curNode in nodes)
                {
                    // Как работает бинарное дерево - не проверял. 
                    // Реализацию со ссылкой на родительский узел - да, можно, но классика это построение на 2х обхектах:
                    //  дерево, управляющее нодами и реализуюее операции наж ними, и сами ноды 
                    //      Объект дерева с корневым нодом (Root)
                    //      У нода только ссылки на Left и Right
                    BinaryTree foundNode = tree.Find(curNode.ID);
                    if (foundNode == null)
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