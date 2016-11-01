using UnityEngine;
using System.Collections;

public class RotateObject : MonoBehaviour
{
    public float rotateSpeed = 50;
    public bool usingRigidbody = true;

    private float time;
    private Rigidbody rb;

	// Use this for initialization
	void Start ()
    {
        rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        if(usingRigidbody == true)
        {
            time = Time.deltaTime;
            rb.transform.Rotate(0, rotateSpeed * time, rotateSpeed * time);
        }
        else
        {
            time = Time.deltaTime;
            transform.Rotate(0, rotateSpeed * time, rotateSpeed * time);
        } 	
	}
}
