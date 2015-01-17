using NUnit.Framework;
using UnityEngine;

[TestFixture]
public class FieldTest
{

    public void CanMoveLowerBoundary()
    {
        var field = CreateField();
        field.Size = Vector2.one*2;
        field.Position = Vector2.zero;
        Create
    }
    private Shape CreateRandomShape()
    {
        
        return new Shape();
    }

    private Field CreateField()
    {
        return new Field();
    }
}