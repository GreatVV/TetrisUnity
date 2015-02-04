using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Square : MonoBehaviour {

    public Vector2 Size = Vector2.one;

    public List<Vector2> Points;

    // Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
	{
	   
	
	}

    public Vector2 Position
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
}
