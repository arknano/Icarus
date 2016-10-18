using UnityEngine;
using System.Collections;

public class NewCameraTest : MonoBehaviour
{
    public float minDistance;
    public float followDistance;
    public GameObject target;
    public Vector3 offset;

    private float velocity;
    private Vector3 targetPos;

	// Use this for initialization
	void Start ()
    {
        targetPos = transform.position;
	}
	
	// Update is called once per frame
	void FixedUpdate ()
    {
	    if(target)
        {
            Vector3 posZ = transform.position;
            posZ.z = target.transform.position.z;

            Vector3 targetDirection = target.transform.position - posZ;

            velocity = targetDirection.magnitude * 5.0f;

            targetPos = transform.position + (targetDirection.normalized * velocity * Time.deltaTime);

            transform.position = Vector3.Lerp(transform.position, targetPos + offset, 0.25f);
            //transform.LookAt(target.transform.position);
        }
	}
}
