using UnityEngine;
using System.Collections;

public class Updraft : MonoBehaviour
{
    [Tooltip("The tag name of the player.")]
    public string PlayerTag = "Player";
    [Tooltip("The amount of force that pushes the player.")]
    public float windIntensity = 50;
    public float windDamping = 0.5f;

    private GlideController gc;
    private bool inWind = false;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //if(gc && inWind == false)
        //{
        //    gc.WindVelocity *= 0.9f;
        //}
    }

    void OnTriggerStay(Collider col)
    {
        inWind = true;
        gc = col.GetComponent<GlideController>();
        if (gc != null)
        {
            gc.WindVelocity = windIntensity * transform.right;
        }
    }

    void OnTriggerExit(Collider col)
    {
        //inWind = true;
        gc = col.GetComponent<GlideController>();
        if (gc != null)
        {
            gc.acceleration = windIntensity * gc.acceleration;
        }
    }
}