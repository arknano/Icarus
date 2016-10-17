using UnityEngine;
using System.Collections;
using InControl;

public class DashScript : MonoBehaviour 
{		
	[Tooltip("How far the glider dashes to the side.")]
	public float dashDistance = 100.0f;
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
				}
				if((Input.GetKeyDown("e")|| device.RightBumper.IsPressed))
				{	
					// Set it to right
					dashDirection = 1;
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
				rb.AddForce(5, 0, 0, ForceMode.Impulse);
                //rb.MovePosition(transform.position + (transform.right * dashDirection * dashDistance * Time.fixedDeltaTime * (lerpSpeed * lerpSpeed)));
				dashRemains -= Time.fixedDeltaTime;
			}
		}
	}
}
