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
        return (transform.TransformPoint(new Vector3(0, -0.4f)) + diff);
    }

    private Vector3 UpPoint(Vector3 diff)
    {
        return (transform.TransformPoint(new Vector3(0, 0.4f)) + diff);
    }

    private Vector3 LeftPoint(Vector3 diff)
    {
        return (transform.TransformPoint(new Vector3(-0.4f, 0f)) + diff);
    }

    private Vector3 RightPoint(Vector3 diff)
    {
        return (transform.TransformPoint(new Vector3(0.4f, 0f)) + diff);
    }
  
    public float MinY(Vector3 diff)
    {
        return Mathf.Min(BottomPoint(diff).y, UpPoint(diff).y, LeftPoint(diff).y, RightPoint(diff).y);
    }

    public bool Intersect(Square square, Vector3 diff)
    {
        var bounds = (square.collider2D as BoxCollider2D).bounds;
        return  bounds.Contains(BottomPoint(diff)) || bounds.Contains(LeftPoint(diff)) || bounds.Contains(RightPoint(diff)) || bounds.Contains(UpPoint(diff));
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(BottomPoint(Vector3.zero), 0.1f);
        Gizmos.color = Color.blue;
        Gizmos.DrawSphere(UpPoint(Vector3.zero), 0.1f);
        Gizmos.color = Color.yellow;
        Gizmos.DrawSphere(LeftPoint(Vector3.zero), 0.1f);
        Gizmos.color = Color.black;
        Gizmos.DrawSphere(RightPoint(Vector3.zero), 0.1f);
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