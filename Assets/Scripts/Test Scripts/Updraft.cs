using UnityEngine;
using System.Collections;

public class Updraft : MonoBehaviour
{
    [Tooltip("The tag name of the player.")]
    public string PlayerTag = "Player";
    [Tooltip("The amount of force that pushes the player.")]
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
        if (col.gameObject.tag == PlayerTag)
        {
            rb = col.gameObject.GetComponent<Rigidbody>();
            rb.AddForce(transform.right * force, ForceMode.Impulse);
        }
    }
}