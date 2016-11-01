using UnityEngine;
using System.Collections;

public class Bounce : MonoBehaviour 
{
	public float bounceIntensity = 50;
	//public float bounceDamping = 0.9f;
	public string wallTag = "Ground";

	private GlideController glide;

	// Use this for initialization
	void Start () 
	{		
		glide = GetComponent<GlideController>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {}

	void OnCollisionEnter(Collision collision)
	{		
		if (collision.gameObject.tag == wallTag)
		{
			glide.BounceVelocity = bounceIntensity * Vector3.Reflect(glide.transform.forward, collision.contacts[0].normal;
			glide.acceleration *= 0.5f;			 
		}
	}
}
