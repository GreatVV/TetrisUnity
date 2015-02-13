using System.Collections.Generic;
using UnityEngine;

public class Field : MonoBehaviour
{
    public Shape ActiveShape;
    public float DefaultVelocity = 10;
    public Vector3 NewPosition;
    public Vector2 Position;
    public ShapeFactory ShapeFactory;
    public Vector2 Size;
    public Vector2 SpawnPosition;
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
        ActiveShape.transform.position = SpawnPosition;
        Velocity = DefaultVelocity;
        NewPosition = ActiveShape.transform.position + new Vector3(0, -1);
    }

    public void Start()
    {
        SpawnPosition = new Vector2(Size.x/2, Size.y);
        Init();
    }

    public void Update()
    {
        var currentPosition = ActiveShape.transform.position;


        if (currentPosition.y < NewPosition.y)
        {
            NewPosition = currentPosition + new Vector3(0, -1);
        }

        if (CanMove(ActiveShape, NewPosition, this))
        {
            ActiveShape.transform.position = currentPosition + Vector3.down*Time.deltaTime*Velocity;
        }
        else
        {
            var newSquares = ActiveShape.Squares;
            foreach (var newSquare in newSquares)
            {
                var position = newSquare.transform.position;
                newSquare.transform.position = new Vector3(
                    Mathf.RoundToInt(position.x),
                    Mathf.RoundToInt(position.y),
                    Mathf.RoundToInt(position.z));
            }

            Squares.AddRange(ActiveShape.Squares);
            CreateNewShape();
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            var flag = true;
            foreach (var square in ActiveShape.Squares)
            {
                if (Mathf.RoundToInt(square.LeftPoint.x) <= 0)
                {
                    flag = false;
                }
            }
            if (flag)
            {
                ActiveShape.transform.position += Vector3.left;
            }
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            var flag = true;
            foreach (var square in ActiveShape.Squares)
            {
                if (Mathf.RoundToInt(square.LeftPoint.x) >= Size.x)
                {
                    flag = false;
                }
            }
            if (flag)
            {
                ActiveShape.transform.position += Vector3.right;
            }
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            ActiveShape.transform.Rotate(0, 0, 90);
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            Velocity = 100;
        }
        if (Input.GetKeyUp(KeyCode.DownArrow))
        {
            Velocity = DefaultVelocity;
        }
    }

    public static bool CanMove(Shape shape, Vector3 newPosition, Field field)
    {
        var lowerBound = newPosition.y + shape.MinY;

        //два условия остановки: нижняя граница поля, снизу есть клетки
        /* foreach (var square in shape.Squares)
        {
            if (Mathf.RoundToInt(square.BottomPoint.y) == 0)
            {
                return false;
            }
        }*/
        if (lowerBound < 0)
        {
            return false;
        }

        //алгоритм
        //пройтись по всем квадратам в фигуре и подсчитать его новые целочисленные координаты
        //проверить если в таких координатах уже квадрат - если есть значит сказать что нельзя двигаться
        foreach (var square in shape.Squares)
        {
            foreach (var point in field.Squares)
            {
                if (Mathf.RoundToInt(point.LeftPoint.x) == Mathf.RoundToInt(square.LeftPoint.x) &&
                    Mathf.RoundToInt(point.LeftPoint.y) == Mathf.RoundToInt(square.LeftPoint.y))
                {
                    return false;
                }
                if (Mathf.RoundToInt(point.BottomPoint.x) == Mathf.RoundToInt(square.BottomPoint.x) &&
                    Mathf.RoundToInt(point.BottomPoint.y) == Mathf.RoundToInt(square.BottomPoint.y))
                {
                    return false;
                }
                if (Mathf.RoundToInt(point.RightPoint.x) == Mathf.RoundToInt(square.RightPoint.x) &&
                    Mathf.RoundToInt(point.RightPoint.y) == Mathf.RoundToInt(square.RightPoint.y))
                {
                    return false;
                }
            }
        }
        /*
        foreach (var square in shape.Squares)
        {
            foreach (var point in square.Points)
            {
                var position = new Vector3(
                    Mathf.RoundToInt(point.x + newPosition.x),
                    Mathf.RoundToInt(point.y + newPosition.y));

                var intersect =
                    field.Squares.Any(x => x.transform.position.y == position.y && x.transform.position.x == position.x);
                if (intersect)
                {
                    return false;
                }
            }
        }
        */

        return true;
    }
}