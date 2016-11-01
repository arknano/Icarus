using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using InControl;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class GlideController : MonoBehaviour
{
    [Tooltip("Whether to use this objects artificial gravity or not.")]
    public bool artificialGravity = true;
    [Tooltip("The speed at which the glider realigns itself.")]
    public float smooth = 1.0f;
    [Tooltip("The speed at which the glider rotates.")]
    public float turningSensitivity = 45.0f;
    [Tooltip("Angle the glider readjusts to when controls are released.")]
    public float reAdjustAngle = 10;
    [Tooltip("The speed the glider readjusts when controls are released.")]
    public float reAdjustRate = 0.4f;
    [Tooltip("How fast the glider can accelerate.")]
    public float acceleration = 30.0f;
    [Tooltip("The glider's max speed.")]
    public float maxVelocity = 100;
    [Tooltip("How quickly the glider slows when aimed upward. Smaller numbers means faster deceleration.")]
    public float upDeccelerate = 65;
    [Tooltip("How fast the glider accelerates when aimed downward. Smaller numbers means faster acceleration.")]
    public float downAccelerate = 50;
	[Tooltip("Use a number between 0.9 and 0.01. The smaller the number, the quicker the dash slows down.")]
	public float dashDamping = 0.9f;
	[Tooltip("Use a number between 0.9 and 0.01. The smaller the number, the quicker you slow down from bouncing off a collision.")]
	public float bounceDamping = 0.9f;
	[Tooltip("Use a number between 0.09 and 0.01. The smaller the number, the quicker you return to normal speed after touching wind currents.")]
	public float windDamping = 0.5f;
	[Tooltip("READ ONLY. To give a speed read out.")]
	public float speed = 0;

    public GameObject gameController;

    private ScoreKeeping sK;

    private float minVelocity = 0; // The lowest possible flight speed.
    private Vector3 angles = Vector3.zero;
    private Rigidbody rb;
    private int score = 0;   

   // public LayerMask terrainLayer;
	public Vector3 bounceVelocity;
	public Vector3 BounceVelocity
	{
		get { return bounceVelocity; }
		set { bounceVelocity = value; }
	}

	public Vector3 windVelocity;
	public Vector3 WindVelocity
	{
		get { return windVelocity; }
		set { windVelocity = value; }
	}

	public Vector3 dashVelocity;
	public Vector3 DashVelocity
	{
		get { return dashVelocity; }
		set { dashVelocity = value; }
	}


    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        sK = gameController.GetComponent<ScoreKeeping>();
		rb.velocity = new Vector3(0,0,200);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
		speed = rb.velocity.magnitude;

        InputDevice device = InputManager.ActiveDevice;

		float horizontal = Input.GetAxis("Horizontal") + device.LeftStick.X; // move horizontal - get the control stick or keyboards horizontal movement input
        float vertical = Input.GetAxis("Vertical") + device.LeftStick.Y; // move vertical - get the control stick or keyboards vertical movement input

		angles.z = Mathf.LerpAngle(angles.z, 0, Time.deltaTime * smooth); // banking reset
        
		//angles.x = Mathf.LerpAngle(angles.x, reAdjustAngle, Time.deltaTime * reAdjustRate); // up and down rotation reset

		float forwardSpeed = Vector3.Dot(transform.forward, rb.velocity);

		// Adjust angles.x based on forward speed.


		angles.x = Mathf.Clamp(angles.x + vertical * turningSensitivity * Time.deltaTime, -60, 90); // up and down rotation with control stick
		angles.y = angles.y + horizontal * turningSensitivity * Time.deltaTime; // left and right rotation
		angles.z = Mathf.Clamp(angles.z + horizontal * -turningSensitivity * Time.deltaTime, -90, 90); // banking rotation 
        transform.eulerAngles = angles;

        rb.velocity = transform.forward * Accelerate() + BounceVelocity + WindVelocity + DashVelocity;
		//acceleration = rb.velocity.z;
		//Debug.Log(rb.velocity.magnitude); 

        //Debug.Log(rb.velocity.magnitude);

        WindVelocity *= windDamping;
        BounceVelocity *= bounceDamping;
		DashVelocity *= dashDamping;

        StartCoroutine(checkPos());
    }

    IEnumerator checkPos()
    {
        Vector3 originalPos = transform.position;
        yield return new WaitForSeconds(2f);
        Vector3 finalPos = transform.position;
        Debug.Log((finalPos - originalPos).magnitude);
        if((finalPos - originalPos).magnitude < 5)
        {
            endGame();
        }
    }

    void endGame()
    {
        Debug.Log("Game Ended");
    }

    float Accelerate()
    {
        // If glider pointed downward and acceleration greater than 0, start to speed up
        if (angles.x > 0 && acceleration > 0)
        {
            // if you are facing down, accelerate quickly
            acceleration += angles.x / (downAccelerate);
        }
        // else if glider pointed down but acceleration is in the negatives due to gravity, after upward flight, 
        // convert the negative acceleration (used for gravity pull) into positive downwards acceleration
        else if (angles.x > 0 && acceleration < 0)
        {
            // if you are facing up, deccelerate slowly - slower than you speed up going down
            acceleration *= -1;
        }
        else if (angles.x < 0)
        {
            // if you are facing up, deccelerate slowly - slower than you speed up going down
            acceleration += angles.x / (upDeccelerate);
        }

        if (acceleration < minVelocity)
        {
            // if in built gravity is not in use, reset acceleration to 0
            if (artificialGravity == false)
            {
                acceleration = minVelocity;
            }
        }
        else if (acceleration > maxVelocity)
        {
            acceleration = maxVelocity;
        }
        return acceleration;
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "ScoreCollectable")
        {
            Destroy(col.gameObject);
            sK.AddScore(col);
        }
    }
}
