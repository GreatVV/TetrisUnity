using System.Collections.Generic;
using UnityEngine;

public class Square : MonoBehaviour
{
    public Vector2 BottomPoint;
    public Vector2 LeftPoint;
    public List<Vector2> Points;
    public Vector2 RightPoint;
    public Vector2 Size = Vector2.one;

    public Vector2 Position
    {
        get { return transform.position; }
        set { transform.position = value; }
    }

    // Use this for initialization
    private void Start()
    {
    }

    // Update is called once per frame
    private void Update()
    {   
        LeftPoint = new Vector2(transform.position.x - 0.5f, transform.position.y);
        BottomPoint = new Vector2(transform.position.x, transform.position.y - 0.5f);
        RightPoint = new Vector2(transform.position.x + 0.5f, transform.position.y);
    }
}