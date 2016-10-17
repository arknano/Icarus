using UnityEngine;
using System.Collections;

public class Updraft : MonoBehaviour {

    public enum DIRECTION
    {
        FROM_ABOVE,
        FROM_BELOW,
        FROM_LEFT,
        FROM_RIGHT
    };

    [Tooltip("The direction the wind comes from.")]
    public DIRECTION direction;

    private Rigidbody rb;

	// Use this for initialization
	void Start ()
    {
	}
	
	// Update is called once per frame
	void FixedUpdate ()
    {  
	}

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Yellow Orb")
        {
        }
    }
}
