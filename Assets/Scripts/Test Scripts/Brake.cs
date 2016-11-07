using UnityEngine;
using InControl;
using System.Collections;

public class Brake : MonoBehaviour
{
    public float isBraking = 0;
    public float brakePower = 10;
    public float brakeCapacity = 100;

    private float currentBrakeCapacity;
    private GlideController gc;

    // Use this for initialization
    void Start()
    {
        gc = GetComponent<GlideController>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        InputDevice device = InputManager.ActiveDevice;

        isBraking = device.RightStickY + Input.GetAxis("Fire1");

        gc.BrakeVelocity = brakePower * -transform.forward * isBraking;
        /*if(isBraking > 0.1f)
        {
            gc.acceleration *= 0.5f;
        }*/
    }
}
