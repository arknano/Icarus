using UnityEngine;
using System.Collections;

public class Bounce : MonoBehaviour 
{
	public float bounceIntensity = 50;
	public float bounceDamping = 0.9f;

	public string wallTag = "Ground";

	private Rigidbody rb;
	private GlideController glide;

	// Use this for initialization
	void Start () 
	{
		rb = GetComponent<Rigidbody>();
		glide = GetComponent<GlideController>();
	}
	
	// Update is called once per frame
	void FixedUpdate () 
	{
		glide.BounceVelocity *= 0.9f;
	}

	void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject.tag == wallTag)
		{
			glide.BounceVelocity = bounceIntensity * collision.contacts[0].normal;
			glide.acceleration *= 0.5f;
			//rb.AddForce(50 * collision.contacts[0].normal, ForceMode.Impulse);    
		}
	}
}
