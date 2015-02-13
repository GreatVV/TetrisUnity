using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Shape : MonoBehaviour
{
    public List<Square> Squares = new List<Square>();

    public float MinY(Vector3 diff)
    {
        return Squares.Min(x => x.MinY(diff));
    }

    public float MinX(Vector3 diff)
    {
        return Squares.Min(x => x.MinX(diff));
    }

    public float MaxX(Vector3 diff)
    {
        return Squares.Max(x => x.MaxX(diff));
    }

    public float MaxY(Vector3 diff)
    {
        return Squares.Max(x => x.MaxY(diff));
    }

    public void AddSquare(Square square, Vector2 position)
    {
        square.transform.SetParent(transform, false);
        square.transform.localPosition = position;
        Squares.Add(square);
    }
}