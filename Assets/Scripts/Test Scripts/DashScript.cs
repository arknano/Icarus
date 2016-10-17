using UnityEngine;
using System.Collections;
using InControl;

public class DashScript : MonoBehaviour 
{		
	[Tooltip("How quickly the glider dashes - faster dash = longer dash.")]
	public float speed = 5.0f;
	private float currentSpeed = 0;
	public float speedFraction = 4;
	private float dashRemains = 0;
	private float dashDirection = 0;

    Rigidbody rb;

	// Use this for initialization
	void Start ()
    {
        rb = GetComponent<Rigidbody>();
    }

	void Update()
	{
		
	}

	void FixedUpdate ()
	{
		InputDevice device = InputManager.ActiveDevice;

		if (device != null) 
		{		
			if (dashRemains <= 0)
			{
				dashDirection = 0;
				if((Input.GetKeyDown("q")|| device.LeftBumper.IsPressed))
				{						
					// Set it to left	
					dashDirection = -1;
					currentSpeed = speed;
				}
				if((Input.GetKeyDown("e")|| device.RightBumper.IsPressed))
				{	
					// Set it to right
					dashDirection = 1;
					currentSpeed = speed;
				}

				if (dashDirection != 0)
				{
					// Duration of the dash
					dashRemains = 1;
				}
			}
			else
			{
				float lerpSpeed = 1 - (1-dashRemains);
				//Debug.Log("hi");
				Vector3 force = transform.right * dashDirection * Time.fixedDeltaTime;
				//transform.position += transform.right * dashDirection * dashDistance * Time.fixedDeltaTime * (lerpSpeed * lerpSpeed);
				rb.AddForce(DashSpeed() * (dashDirection * transform.right.x), transform.right.y, transform.right.z, ForceMode.Impulse);
                //rb.MovePosition(transform.position + (transform.right * dashDirection * dashDistance * Time.fixedDeltaTime * (lerpSpeed * lerpSpeed)));
				dashRemains -= Time.fixedDeltaTime;
			}
		}
	}

	float DashSpeed()
	{
		if (currentSpeed > 0)
		{
			currentSpeed -= 0.5f;
		}
		else if (speed < 0)
		{
			currentSpeed = 0;
		}
		return currentSpeed;
	}
}
