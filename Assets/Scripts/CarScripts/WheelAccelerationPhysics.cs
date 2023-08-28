using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelAccelerationPhysics : MonoBehaviour
{
    // GameObjects and components
    Rigidbody rb;

    // variables
    [SerializeField] float maxSpeed = 30.0f;
    [SerializeField] float accelerationForce = 10000.0f;
    [SerializeField] AnimationCurve powerCurve;

    void Start()
    {
        rb = transform.parent.gameObject.GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        if (SuspensionPhysics.isGrounded)
        {
            rb.AddForceAtPosition(transform.forward * Input.GetAxis("Vertical") * accelerationForce * powerCurve.Evaluate(rb.velocity.magnitude / maxSpeed), transform.position);
        }
    }
}
