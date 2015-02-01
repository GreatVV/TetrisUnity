using NUnit.Framework;
using UnityEngine;

[TestFixture]
public class FieldTest
{
    [Test]
    public void CanMoveLowerBoundary()
    {
        var field = CreateField2x2();
        var shape = CreateShape();
        
        shape.transform.position = new Vector3(0,1);
        
        var nextPosition = new Vector2(0, -1);

        var canMove = Field.CanMove(shape, nextPosition, field);

        Assert.IsFalse(canMove);
    }

    private Shape CreateShape()
    {
        return new GameObject("Shape", typeof (Shape)).GetComponent<Shape>();
    }

    private Field CreateField2x2()
    {
        var field = new GameObject("Field", typeof (Field)).GetComponent<Field>();
        field.Size = Vector2.one * 2;
       // field.Position = Vector2.zero;
        return field;
    }
}