using UnityEngine;
using System.Collections;

public class Updraft : MonoBehaviour
{
    [Tooltip("The tag name of the player.")]
    public string PlayerTag = "Player";
    [Tooltip("The amount of force that pushes the player.")]
    public float windIntensity = 50;   
	[Tooltip("How quickly the wind affects acceleration, between 0.01 and 1. The value 0.01 is slowest, 1 is fastest.")]
	public float boostRate = 0.4f;

    private GlideController gc;
    //private bool inWind = false;

    // Use this for initialization
    void Start() { }
    // Update is called once per frame
    void FixedUpdate() { }

    void OnTriggerStay(Collider col)
    {
        //inWind = true;
        gc = col.GetComponent<GlideController>();
        if (gc != null)
        {
			gc.WindVelocity = windIntensity * transform.right;

			// high +ve values = high tailwind, high -ve = headwind, zero = wind is side-on
			float tailwind = Vector3.Dot(gc.transform.forward, transform.right) * windIntensity;
			gc.acceleration += tailwind * Time.deltaTime * boostRate;
			Debug.Log(gc.acceleration);
        }
    }
}