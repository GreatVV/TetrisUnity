using NUnit.Framework;
using UnityEngine;

[TestFixture]
public class FieldTest
{
    [Test]
    public void CanMoveLowerBoundary()
    {
        var field = CreateField();
        field.Size = Vector2.one*2;
        field.Position = Vector2.zero;

        var shape = CreateShape();
        shape.transform.position = new Vector3(0,1);
        
        var nextPosition = new Vector2(0, -1);
        
        var canMove = Field.CanMove(shape, nextPosition);

        Assert.IsFalse(canMove);

    }
    private Shape CreateShape()
    {
        var shapeFactory = Object.FindObjectOfType<ShapeFactory>();
        return shapeFactory.CreateSquare();
    }

    private Field CreateField()
    {
        var field = Object.FindObjectOfType<Field>();
        return field;
    }
}