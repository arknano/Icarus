using UnityEngine;
using System.Collections;
using InControl;

public class DashScript : MonoBehaviour 
{		
	[Tooltip("How quickly the glider dashes - faster dash = longer dash.")]
	public float dashSpeed = 6.0f;
	[Tooltip("How long you have to wait between dashes.")]
	public float dashCooldown = 70.0f;

	private float dashLeft = 0;
	private float currentSpeed = 0;
	private float dashRemains = 0;
	private float dashDirection = 0;
	private bool keyDown = false;

	//public int counter = 0;

    Rigidbody rb;

	// Use this for initialization
	void Start ()
    {
        rb = GetComponent<Rigidbody>();
    }

	void FixedUpdate ()
	{
		InputDevice device = InputManager.ActiveDevice;

		if (device != null) 
		{		
			if((Input.GetKeyUp("q") || !(device.LeftBumper.IsPressed)) && (Input.GetKeyUp("3") || !(device.RightBumper.IsPressed)))
			{
				keyDown = false;
			}

			if (currentSpeed <= 0)
			{	
				DashCoolDown();
				if (keyDown == false && dashLeft <= 0)
				{
					dashDirection = 0;
					if((Input.GetKeyDown("q")|| device.LeftBumper.IsPressed))
					{						
						// Set it to left
						dashDirection = -1;
						currentSpeed = dashSpeed;
						dashLeft = dashCooldown;
						keyDown = true;
					}
					if((Input.GetKeyDown("e")|| device.RightBumper.IsPressed))
					{	
						// Set it to right
						dashDirection = 1;
						currentSpeed = dashSpeed;
						dashLeft = dashCooldown;
						keyDown = true;
					}
				}

			}
			else
			{
				rb.AddForce(DashSpeed() * (dashDirection * transform.right), ForceMode.Impulse);               
			}
		}
	}

	void DashCoolDown()
	{
		if(dashLeft > 0)
		{
			//Debug.Log(dashLeft);
			dashLeft -= 1;
		}
	}

	float DashSpeed()
	{
		if (currentSpeed > 0)
		{
			currentSpeed -= 0.5f;
		}
		else if (currentSpeed <= 0)
		{			
			currentSpeed = 0;
		}
		return currentSpeed;
	}
}
