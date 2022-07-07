using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Models
{
    public abstract class PathFinder : MonoBehaviour
    {
        protected List<Vector2> path = new List<Vector2>();

        protected List<Vector2Int> directions = new List<Vector2Int>();

        public PathFinder()
        {
            directions.Add(Vector2Int.up);
            directions.Add(Vector2Int.right);
            directions.Add(Vector2Int.down);
            directions.Add(Vector2Int.left);
        }
        public virtual List<Vector2> GetNodeList(Vector2Int position, Vector2Int target)
        {
            return path;
        }
        
        /// <summary>
        /// Очищает список
        /// <para>Эмммм... а зачем было до этого выделять новый список, если можно этот очистить?</para>
        /// </summary>
        protected void ResetLists()
        {
            path.Clear();
        }
        
        /// <summary>
        /// Возвращает перечисление узлов-соседей
        /// <para>В отличии от укомлектования в список, здесь выделяется память только на создание объекта Генератора,
        /// который тут же диспозится по завершении работы с ним</para>
        /// <para>Почитай про IEnumerable, когда в них появляются значения, хранятся ли они где-то?</para>
        /// </summary>
        protected IEnumerable<Node> GetNeighbourNodes(Node node)
        {
            foreach (Vector2Int direction in directions)
            {
                if (!GetTile.instance.isObstacle(node.position + direction))
                {
                    yield return new Node(node.position + direction, node);
                }
            }
        }

        protected List<Vector2> CreatePath(Node node)
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
}
