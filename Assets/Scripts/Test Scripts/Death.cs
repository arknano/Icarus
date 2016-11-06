using UnityEngine;
using System.Collections;

public class Death : MonoBehaviour {

    public ParticleSystem explosion;
    
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
        Vector3 ray = col.transform.position - transform.position;
        Physics.Raycast()
    }

}
