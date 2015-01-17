using UnityEngine;
using System.Collections;

public class Square : MonoBehaviour {

    public Vector2 Size = Vector2.one;

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
