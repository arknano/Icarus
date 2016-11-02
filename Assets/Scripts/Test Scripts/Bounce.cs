using UnityEngine;
using System.Collections;

public class Bounce : MonoBehaviour 
{
	public float bounceIntensity = 50;
	//public float bounceDamping = 0.9f;
	public string obstacleTag = "Obstacle";
	public string groundTag = "Ground";

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
		if (collision.gameObject.tag == groundTag )
		{
			if (collision.contacts[0].normal.y >= 0.3f)
			{
				Debug.Log("Death");
				glide.BounceVelocity = bounceIntensity * Vector3.Reflect(glide.transform.forward, collision.contacts[0].normal);
				glide.acceleration *= 0.5f;
			}
			else if (collision.contacts[0].normal.y < 0.3f)
			{
				Debug.Log("ALIVE!!!!!");
				glide.BounceVelocity = bounceIntensity * Vector3.Reflect(glide.transform.forward, collision.contacts[0].normal);
				glide.acceleration *= 0.5f;
			}					 
		}
		else if (collision.gameObject.tag == obstacleTag)
		{
			glide.BounceVelocity = bounceIntensity * Vector3.Reflect(glide.transform.forward, collision.contacts[0].normal);
			glide.acceleration *= 0.5f;	
		}	
	}
}
