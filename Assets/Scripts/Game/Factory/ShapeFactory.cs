using UnityEngine;
using System.Collections;

public class ShapeFactory : MonoBehaviour
{

    public GameObject ShapePrefab;


	// Use this for initialization
	void Start () {
	    Create();
	}

    public void Create()
    {
        var shape = (new GameObject("NameOfShape", typeof (Shape))).GetComponent<Shape>();

        var s00 = CreateSquareAndAsChild(shape, new Vector2(0,0));
        var s10 = CreateSquareAndAsChild(shape, new Vector2(1,0));
        var s01 = CreateSquareAndAsChild(shape, new Vector2(0,1));
        var s11 = CreateSquareAndAsChild(shape, new Vector2(1,1));

    }

    private GameObject CreateSquareAndAsChild(Shape shape, Vector2 position)
    {
        var square = Instantiate(ShapePrefab) as GameObject;
        square.transform.SetParent(shape.transform, false);
        square.transform.localPosition = position;
        return square;
    }
}
