using UnityEngine;

namespace Models
{
    public class Node
    {
        public long ID { get; }
        public Vector2Int position { get; }
        public Node previousNode { get; }
        
        // Так как информация ниже не нужна для ячейки волнового алгоритма, то тогда нужно было запилить наследника,
        // в конструктор которого эту инфу и передать
        public Vector2Int targetPosition { get; }
        public int cost { get; } // ��� A*
        
        private readonly int _remoteDistance;
        private readonly int _distanceToTarget;

        private Node(Vector2Int position) {
            ID = GetTile.instance.GetNodeId(in position);
            
            // Ну это прям извращение. Прога небойсь поэтому так долго и работает)))
            // ID = int.Parse((Mathf.Abs(GetTile.instance.MinX()) + position.x) +
            //                (Mathf.Abs(GetTile.instance.MinY()) + position.y).ToString());
            
            this.position = position;
        }
        public Node(Vector2Int position, Vector2Int targetPosition) : this(position)
        {
            this.targetPosition = targetPosition;
        }
        public Node(Vector2Int position, Node previousNode) : this(position)
        {
            this.previousNode = previousNode;

            targetPosition = previousNode.targetPosition;
            _remoteDistance = previousNode._remoteDistance + 1;
            _distanceToTarget = Mathf.RoundToInt(Mathf.Abs(targetPosition.x - position.x) + Mathf.Abs(targetPosition.y - position.y));
            cost = _remoteDistance + _distanceToTarget;
        }
    }
}
