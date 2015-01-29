using System.Collections.Generic;
using System.Linq;
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
        ActiveShape.transform.position = Position + new Vector2(Size.x / 2, Size.y);
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
            //TODO сделать проверку на границы
            ActiveShape.transform.position += Vector3.left;
        }

        if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            //TODO сделать проверку на границы
            ActiveShape.transform.position += Vector3.right;
        }
    }

    public static bool CanMove(Shape shape, Vector3 newPosition, Field field)
    {
        var lowerBound = newPosition.y + shape.MinY;

        //два условия остановки: нижняя граница поля, снизу есть клетки
        //lowerBondary
        if (lowerBound < field.Position.y)
        {
            return false;
        }

        //алгоритм
        //пройтись по всем квадратам в фигуре и подсчитать его новые целочисленные координаты
        //проверить если в таких координатах уже квадрат - если есть значит сказать что нельзя двигаться
        foreach (var square in shape.Squares)
        {
            var position = new Vector3(
                Mathf.RoundToInt(square.transform.localPosition.x + newPosition.x),
                Mathf.RoundToInt(square.transform.localPosition.y + newPosition.y));

            var intersect =
                field.Squares.Any(x => x.transform.position.y == position.y && x.transform.position.x == position.x);
            if (intersect)
            {
                return false;
            }
        }

        return true;
    }
}