using UnityEngine;
using System.Collections;

public class NewCameraTest : MonoBehaviour
{
    public GameObject target;
    public float distance;
    public float height;
    public float rotationOffset = 0.1f;

    private Vector3 direction;
    private Vector3 targetPosition;
    private Rigidbody rb;
    // Use this for initialization
    void Start ()
    {
        rb = target.GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void FixedUpdate ()
    {
	    if(target)
        {
            direction = -(rb.velocity.normalized);

            targetPosition = target.transform.position + (direction * distance) + (Vector3.up * height);

            transform.position = targetPosition;
            transform.LookAt(target.transform);

            transform.rotation = Quaternion.Lerp(transform.rotation, target.transform.rotation, rotationOffset);
        }
    }
}
