using UnityEngine;
using System.Collections;

public class RotateObject : MonoBehaviour
{
    float time;

	// Use this for initialization
	void Start ()
    {
	
	}
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        time = Time.deltaTime;
        transform.Rotate(0, 50 * time, 50 * time); 	
	}
}
