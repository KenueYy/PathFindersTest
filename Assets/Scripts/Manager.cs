using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Manager : MonoBehaviour
{
    [SerializeField] private PathFinderType pathFinderType;
    [SerializeField] private View view;
    [SerializeField] private KeyCode keyCode;

    private PathFinder pathFinder;
    private Vector2 firstPoint, secondPoint;
    public enum PathFinderType
    {
        LeeAlgorithm,
        AStar
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
            view.SetPath(pathFinder.GetNodeList(firstPoint, secondPoint)); 
        }
    }
}
 