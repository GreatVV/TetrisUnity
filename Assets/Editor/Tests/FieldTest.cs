using NUnit.Framework;

[TestFixture]
public class FieldTest
{
    [Test]
    public void AddFigureToField()
    {
        var field = CreateField();
        var shape = CreateRandomShape();

        field.AddShape(shape);

        Assert.That(field.Shapes.Contains(shape));
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