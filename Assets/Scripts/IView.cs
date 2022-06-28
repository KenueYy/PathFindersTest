using System.Collections.Generic;
using UnityEngine;

public interface IView
{
    void SetFirstPoint(Vector2 position);
    void SetPath(List<Vector2> path);
    void SetSecondPoint(Vector2 position);
}