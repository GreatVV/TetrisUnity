using System.Collections.Generic;
using System.Linq;
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
            if (ActiveShape.transform.position.x > 0)
            {
                ActiveShape.transform.position += Vector3.left;
            }
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (ActiveShape.transform.position.x < Size.x)
            {
                ActiveShape.transform.position += Vector3.right;
            }
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            //ActiveShape.transform.rotation = Quaternion.Euler(0, 0, ActiveShape.transform.rotation.z + 90);
            ActiveShape.transform.Rotate(0, 0, 90);
            //как я понял он считает границу фигуры по minY и если мы крутим фигуру, то minY остается на том же квадрате. 
            //значит надо при кручении менять minY.
            // ActiveShape.MinY = Squares.Min(x => x.transform.localPosition.y - x.Size.y/2f);
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
        var lowerBound = newPosition.y+ shape.MinY;

        //два условия остановки: нижняя граница поля, снизу есть клетки
        //lowerBondary
        if (lowerBound < 0)
        {
            return false;
        }

        //алгоритм
        //пройтись по всем квадратам в фигуре и подсчитать его новые целочисленные координаты
        //проверить если в таких координатах уже квадрат - если есть значит сказать что нельзя двигаться
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

        return true;
    }
}