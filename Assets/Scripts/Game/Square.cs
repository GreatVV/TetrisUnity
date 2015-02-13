using System.Collections.Generic;
using UnityEngine;

public class Square : MonoBehaviour
{
    public Vector2 Size = Vector2.one;

    public Vector3 Position
    {
        get
        {
            return transform.position;
        }
        set
        {
            transform.position = value;
        }
    }

    private Vector3 BottomPoint(Vector3 diff)
    {
        return RoundVector(transform.TransformPoint(new Vector3(0, -0.5f)) + diff);
    }

    private Vector3 UpPoint(Vector3 diff)
    {
        return RoundVector(transform.TransformPoint(new Vector3(0, 0.5f)) + diff);
    }

    private Vector3 LeftPoint(Vector3 diff)
    {
        return RoundVector(transform.TransformPoint(new Vector3(-0.5f, 0f)) + diff);
    }

    private Vector3 RightPoint(Vector3 diff)
    {
        return RoundVector(transform.TransformPoint(new Vector3(0.5f, 0f)) + diff);
    }

    private Vector3 RoundVector(Vector3 vector)
    {
        return new Vector3(Mathf.RoundToInt(vector.x), Mathf.RoundToInt(vector.y), Mathf.RoundToInt(vector.z));
    }

    public float MinY(Vector3 diff)
    {
        return Mathf.Min(BottomPoint(diff).y, UpPoint(diff).y, LeftPoint(diff).y, RightPoint(diff).y);
    }

    public bool Intersect(Square square, Vector3 diff)
    {
        return square.Position == BottomPoint(diff) || square.Position == LeftPoint(diff) ||
               square.Position == RightPoint(diff) || square.Position == UpPoint(diff);
    }

    public float MinX(Vector3 diff)
    {
        return Mathf.Min(BottomPoint(diff).x, UpPoint(diff).x, LeftPoint(diff).x, RightPoint(diff).x);
    }

    public float MaxX(Vector3 diff)
    {
        return Mathf.Max(BottomPoint(diff).x, UpPoint(diff).x, LeftPoint(diff).x, RightPoint(diff).x);
    }

    public float MaxY(Vector3 diff)
    {
        return Mathf.Max(BottomPoint(diff).y, UpPoint(diff).y, LeftPoint(diff).y, RightPoint(diff).y);
    }
}