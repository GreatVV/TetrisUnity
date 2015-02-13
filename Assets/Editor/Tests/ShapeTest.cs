using NUnit.Framework;
using UnityEngine;
using System.Collections;
using System.Runtime.InteropServices.ComTypes;

[TestFixture]
public class ShapeTest
{
    [Test]
    public void MinBoundaryTestOnSquareWithMinusPosition()
    {
        var expectedMinY = -1;

        var shape = CreateShapeWithoutSquares();

        var square = CreateSquare();
        square.Size = new Vector2(1,1);

        shape.AddSquare(square, new Vector2(0, -0.5f));

        Assert.AreEqual(expectedMinY, shape.MinY(Vector3.zero));
    }

    private Square CreateSquare()
    {
        return new GameObject("Square", typeof (Square)).GetComponent<Square>();
    }

    private ShapeFactory GetShapeFactory()
    {
        return Object.FindObjectOfType<ShapeFactory>();
    }

    private Shape CreateShapeWithoutSquares()
    {
        return new GameObject("Shape", typeof (Shape)).GetComponent<Shape>();
    }
}