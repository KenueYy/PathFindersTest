using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exceptions : MonoBehaviour
{
    public static Exceptions instance;
    public Exception exception;
    public enum Exception
    {
        NodeIsNotWalkable,
        Other
    }
    public Exceptions()
    {
        instance = this;
    }
}
