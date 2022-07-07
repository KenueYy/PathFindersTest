using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;


public class GetTile : MonoBehaviour
{
    public List<Tilemap> walkables;
    public List<Tilemap> obstacles;

    public static GetTile instance;
    [SerializeField] private Vector2Int leftUpPoint;
    [SerializeField] private Vector2Int rightDownPoint;
    
    /// <summary>
    /// Чтобы получить корректный ID ячейки, нужно знать резмеры поля
    /// <para>Идеальный вариант был бы кэшировать значения, а не вычислять каждый раз,
    /// но в этом случае тогда бы пришлось отслеживать изменения (лень сейчас это делать)</para>
    /// </summary>
    internal Vector2Int FieldSize => new Vector2Int(Mathf.Abs(rightDownPoint.x - leftUpPoint.x), Mathf.Abs(leftUpPoint.y - rightDownPoint.y));


    public GetTile()
    {
        instance = this;
    }
    public void Start()
    {
        //Normalize();
    }
    public bool isObstacle(Vector2 position)
    {
        foreach (Tilemap tilemap in obstacles)
        {
            if (tilemap.GetTile(tilemap.WorldToCell(position)))
            {
                return true;
            }
            else
            {
                foreach (Tilemap walkable in walkables)
                {
                    if (walkable.GetTile(walkable.WorldToCell(position)))
                    {
                        return false;
                    }
                }
            }
        }
        return true;
    }

    /// <summary>
    /// Возвращает ID ячейки, полученный исходя из размера поля
    /// </summary>
    internal long GetNodeId(in Vector2Int position) {
        // Получаем размер поля [X - ширина (кол-во столбцов); Y - высота (кол-во строк)]
        var fieldSize = FieldSize;

        // Фиксируем индекс колонки (Х) и индекс строки (Y) отностиельно начала поля (левого нижнего угла)
        Vector2Int positionIndexes = new Vector2Int(position.x - Mathf.Abs(GetTile.instance.MinX()), 
                                                    position.y - Mathf.Abs(GetTile.instance.MinY()));

        // ИД = Индекс строки (высота, Y) * кол-во стролбцов в поле (ширина поля, Х) + индекс столбца (ширина, X)
        return (positionIndexes.y * fieldSize.x) + positionIndexes.x;
    }
    

    public int MinX() {
        return leftUpPoint.x > rightDownPoint.x ? rightDownPoint.x : leftUpPoint.x;
    }
    public int MinY() {
        return leftUpPoint.y > rightDownPoint.y ? rightDownPoint.y : leftUpPoint.y;
    }
    //private void Normalize()
    //{
    //    leftUpPoint = new Vector2(Mathf.Round(leftUpPoint.x), Mathf.Round(leftUpPoint.y));
    //    rightDownPoint = new Vector2(Mathf.Round(rightDownPoint.x), Mathf.Round(rightDownPoint.y));
    //}
}
