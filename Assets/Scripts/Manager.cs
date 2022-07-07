using UnityEngine;
using Algoritms;
using Models;
using Utils.Extensions;
using Views;

namespace Controllers
{
    public class Manager : MonoBehaviour
    {
        [SerializeField] private PathFinderType pathFinderType;
        [SerializeField] private KeyCode keyCode;

        private IView view;

        private PathFinder pathFinder;
        private Vector2 firstPoint, secondPoint;
        public enum PathFinderType
        {
            LeeAlgorithm,
            AStar,
        }
        public void Start()
        {
            switch (pathFinderType)
            {
                case PathFinderType.AStar:
                    pathFinder = GetComponent<AStar>();
                    break;
                case PathFinderType.LeeAlgorithm:
                    pathFinder = GetComponent<AlgorithmLee>();
                    break;
            }
            view = GetComponent<View>();
        }
        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                firstPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                view.SetFirstPoint(firstPoint);
            }
            if (Input.GetMouseButtonDown(1))
            {
                secondPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                view.SetSecondPoint(secondPoint);
            }
            if (Input.GetKeyDown(keyCode))
            {
                // Добавил экстенш преобразования в Vector2Int.
                // Чтобы получить тот самый уникальный код ячейки, нужно преобразовать координаты в интовые и работать с интовыми координатами
                view.SetPath(pathFinder.GetNodeList(firstPoint.ToVector2Int(), secondPoint.ToVector2Int()));
            }
        }
    }
}
 