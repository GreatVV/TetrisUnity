using System.Collections.Generic;
using UnityEngine;

public class Field : MonoBehaviour
{
    public List<Shape> Shapes { get; private set; }

    private void Init()
    {
        if (Shapes == null)
        {
            Shapes = new List<Shape>();
        }
    }

    public void AddShape(Shape shape)
    {
        Init();
        Shapes.Add(shape);
    }
}