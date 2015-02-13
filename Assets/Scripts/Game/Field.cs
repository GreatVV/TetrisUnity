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
        
    }

    public void Start()
    {
       SpawnPosition = new Vector2(Size.x/2, Size.y);
        Init();
    }

    public void Update()
    {
        var currentPosition = ActiveShape.transform.position;
        var newPosition = currentPosition + Vector3.down*Time.deltaTime*Velocity;

        if (CanMove(ActiveShape, newPosition, this))
        {
            ActiveShape.transform.position = newPosition;
        }
        else
        {
            //set to last possible
            ActiveShape.transform.position = newPosition.RoundToInt();
            Squares.AddRange(ActiveShape.Squares);
            CreateNewShape();
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            var leftPos = currentPosition + Vector3.left;
            if (CanMove(ActiveShape, leftPos, this) && leftPos.x >= 0)
            {
                ActiveShape.transform.position += Vector3.left;
            }
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            var rightPos = currentPosition + Vector3.right;
            if (CanMove(ActiveShape, rightPos, this) && rightPos.x < Size.x)
            {
                ActiveShape.transform.position += Vector3.right;
            }
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            var rotationAngle = new Vector3(0, 0, 90);
            if (CanRotate(rotationAngle, ActiveShape, this))
            {
                ActiveShape.transform.Rotate(0, 0, 90);
            }
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

    private static bool CanRotate(Vector3 rotationAngle, Shape activeShape, Field field)
    {
        //write a check
        activeShape.transform.Rotate(rotationAngle);
        var canMove = CanMove(activeShape, activeShape.transform.position, field);
        activeShape.transform.Rotate(rotationAngle * -1);
        return canMove;
    }

    public static bool CanMove(Shape shape, Vector3 newPosition, Field field)
    {
        var diff = newPosition - shape.transform.position;
        var lowerBound = shape.MinY(diff);

        //два условия остановки: нижняя граница поля, снизу есть клетки
        if (lowerBound < 0)
        {
            return false;
        }

        //алгоритм
        //пройтись по всем квадратам в фигуре и подсчитать его новые целочисленные координаты
        //проверить если в таких координатах уже квадрат - если есть значит сказать что нельзя двигаться
        bool any = false;
        foreach (Square square in shape.Squares.Where(x=>x.Position.x >= shape.MinX(diff) && x.Position.x <= shape.MaxX(diff)))
        {
            foreach (var point in field.Squares)
            {
                if (square.Intersect(point, diff))
                {
                    any = true;
                    break;
                }
            }
        }
        return !any;
       
    }
}