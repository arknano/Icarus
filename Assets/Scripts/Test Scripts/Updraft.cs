﻿using UnityEngine;
using System.Collections;

public class Updraft : MonoBehaviour {

    public string PlayerTag = "Player";
    public float force = 5;

    private Rigidbody rb;

	// Use this for initialization
	void Start ()
    {
	}
	
	// Update is called once per frame
	void FixedUpdate ()
    {  
	}

    void OnCollisionEnter(Collision col)
    {
        Debug.Log("Collided");
        if (col.gameObject.tag == PlayerTag)
        {
            Debug.Log("Registered");
            rb = col.gameObject.GetComponent<Rigidbody>();

            Vector3 dir = col.contacts[0].point - col.gameObject.transform.position;
            dir = -dir.normalized;
            rb.AddForce(dir * force);  
        }
    }
}