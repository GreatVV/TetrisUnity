using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Shape : MonoBehaviour
{
    public float MinY;
    public List<Square> Squares = new List<Square>();
    // Use thisfor initialization
    private void Start()
    {
    }

    // Update is called once per frame
    private void Update()
    {
    }

    public void AddSquare(Square square, Vector2 position)
    {
        square.transform.SetParent(transform, false);
        square.transform.localPosition = position;

        Squares.Add(square);

        MinY = Squares.Min(x => x.transform.localPosition.y - x.Size.y/2f);
    }
}