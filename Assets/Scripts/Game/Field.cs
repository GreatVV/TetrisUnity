using System.Collections.Generic;
using UnityEngine;

public class Field : MonoBehaviour
{
    public Shape ActiveShape;
    public float DefaultVelocity = 10;
    public Vector2 Position;
    public ShapeFactory ShapeFactory;
    public Vector2 Size;
    public List<Square> Squares = new List<Square>();
    public float Velocity;

    private void Init()
    {
        CreateNewShape();
    }

    public void CreateNewShape()
    {
        ActiveShape = ShapeFactory.CreateRandom();
        ActiveShape.transform.SetParent(transform);
        ActiveShape.transform.position = Position + new Vector2(Size.x/2, Size.y);
    }

    public void Start()
    {
        Init();
        Velocity = DefaultVelocity;
    }

    public void Update()
    {
        var currentPosition = ActiveShape.transform.position;
        var newPosition = currentPosition + Vector3.down * Time.deltaTime * Velocity;

        if (CanMove(ActiveShape, newPosition, this))
        {
            ActiveShape.transform.position = newPosition;
        }
        else
        {
            Squares.AddRange(ActiveShape.Squares);
            CreateNewShape();
        }
    }

    public static bool CanMove(Shape shape, Vector3 newPosition, Field field)
    {
        var currentPosition = shape.transform.position;

        //два условия остановки: нижняя граница поля, снизу есть клетки
        //lowerBondary
        if (newPosition.y + shape.MinY < field.Position.y)
        {
            return false;
        }


        //hasSquares
        return true;
    }
}