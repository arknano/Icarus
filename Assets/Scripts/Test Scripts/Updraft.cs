﻿using UnityEngine;
using System.Collections;

public class Updraft : MonoBehaviour
{

    public string PlayerTag = "Player";
    public float force = 5;

    private Rigidbody rb;

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void FixedUpdate()
    {


    }

    void OnTriggerEnter(Collider col)
    {
        Debug.Log("Collided");
        if (col.gameObject.tag == PlayerTag)
        {
            Debug.Log("Registered");
            rb = col.gameObject.GetComponent<Rigidbody>();

            /*Vector3 dir = col.gameObject.transform.position - gameObject.transform.position;
            dir = -dir.normalized;*/
            //rb.AddForce(20, 0, 0, ForceMode.Impulse);
            rb.AddForce(transform.right * force, ForceMode.Impulse);
        }
    }
}