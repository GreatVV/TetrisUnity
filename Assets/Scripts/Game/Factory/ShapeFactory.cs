using UnityEngine;

public class ShapeFactory : MonoBehaviour
{
    public GameObject SquarePrefab;
    // Use this for initialization
    private void Start()
    {
    }

    public Shape CreateSquare()
    {
        var shape = (new GameObject("Square", typeof (Shape))).GetComponent<Shape>();

        var s00 = CreateSquareAndAsChild(shape, new Vector2(0, 0));
        var s10 = CreateSquareAndAsChild(shape, new Vector2(1, 0));
        var s01 = CreateSquareAndAsChild(shape, new Vector2(0, 1));
        var s11 = CreateSquareAndAsChild(shape, new Vector2(1, 1));
        return shape;
    }

    public Shape CreateLine()
    {
        var shape = (new GameObject("Line", typeof (Shape))).GetComponent<Shape>();

        var s00 = CreateSquareAndAsChild(shape, new Vector2(0, 0));
        var s10 = CreateSquareAndAsChild(shape, new Vector2(0, 1));
        var s20 = CreateSquareAndAsChild(shape, new Vector2(0, 2));
        var s30 = CreateSquareAndAsChild(shape, new Vector2(0, 3));
        return shape;
    }

    public Shape CreateJShape()
    {
        var shape = (new GameObject("JShape", typeof (Shape))).GetComponent<Shape>();

        var s00 = CreateSquareAndAsChild(shape, new Vector2(0, 0));
        var s10 = CreateSquareAndAsChild(shape, new Vector2(1, 0));
        var s01 = CreateSquareAndAsChild(shape, new Vector2(2, 0));
        var s11 = CreateSquareAndAsChild(shape, new Vector2(0, 1));
        return shape;
    }

    public Shape CreateLShape()
    {
        var shape = (new GameObject("LShape", typeof (Shape))).GetComponent<Shape>();

        var s00 = CreateSquareAndAsChild(shape, new Vector2(0, 0));
        var s10 = CreateSquareAndAsChild(shape, new Vector2(1, 0));
        var s01 = CreateSquareAndAsChild(shape, new Vector2(2, 0));
        var s11 = CreateSquareAndAsChild(shape, new Vector2(2, 1));
        return shape;
    }

    public Shape CreateSShape()
    {
        var shape = (new GameObject("SShape", typeof (Shape))).GetComponent<Shape>();

        var s00 = CreateSquareAndAsChild(shape, new Vector2(0, 0));
        var s10 = CreateSquareAndAsChild(shape, new Vector2(1, 0));
        var s01 = CreateSquareAndAsChild(shape, new Vector2(1, 1));
        var s11 = CreateSquareAndAsChild(shape, new Vector2(2, 1));
        return shape;
    }

    public Shape CreateZShape()
    {
        var shape = (new GameObject("ZShape", typeof (Shape))).GetComponent<Shape>();

        var s00 = CreateSquareAndAsChild(shape, new Vector2(0, 0));
        var s10 = CreateSquareAndAsChild(shape, new Vector2(1, 0));
        var s01 = CreateSquareAndAsChild(shape, new Vector2(1, -1));
        var s11 = CreateSquareAndAsChild(shape, new Vector2(2, -1));
        return shape;
    }

    public Shape CreateTShape()
    {
        var shape = (new GameObject("TShape", typeof (Shape))).GetComponent<Shape>();

        var s00 = CreateSquareAndAsChild(shape, new Vector2(0, 0));
        var s10 = CreateSquareAndAsChild(shape, new Vector2(1, 0));
        var s01 = CreateSquareAndAsChild(shape, new Vector2(2, 0));
        var s11 = CreateSquareAndAsChild(shape, new Vector2(1, 1));
        return shape;
    }

    private GameObject CreateSquareAndAsChild(Shape shape, Vector2 position)
    {
        var square = Instantiate(SquarePrefab) as GameObject;
        square.transform.SetParent(shape.transform, false);
        square.transform.localPosition = position;
        shape.Squares.Add(square.GetComponent<Square>());
        return square;
    }

    public Shape CreateRandom()
    {
        var random = Random.Range(0, 7);
        switch (random)
        {
            case 0:
                return CreateSquare();
                break;
            case 1:
                return CreateTShape();
                break;
            case 2:
                return CreateJShape();
                break;
            case 3:
                return CreateLShape();
                break;
            case 4:
                return CreateLine();
                break;
            case 5:
                return CreateZShape();
                break;
            case 6:
                return CreateSShape();
                break;
        }
        return null;
    }
}