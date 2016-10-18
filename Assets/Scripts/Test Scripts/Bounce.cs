using UnityEngine;
using System.Collections;

public class Bounce : MonoBehaviour 
{

	private Rigidbody rb;

	// Use this for initialization
	void Start () 
	{
		rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void FixedUpdate () 
	{
		
	}

	void OnTriggerEnter(Collider col)
	{
		if (col.gameObject.tag == "Ground")
		{
			rb.AddForce(50 * (transform.forward * -1), ForceMode.Impulse);    
		}
	}
}
