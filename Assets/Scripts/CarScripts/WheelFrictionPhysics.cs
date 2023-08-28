using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelFrictionPhysics : MonoBehaviour
{
    // GameObjects and components
    Rigidbody rb;

    // variables
    [SerializeField] bool frontWheel;
    [SerializeField] AnimationCurve frictionCurveRearWheels;
    [SerializeField] AnimationCurve frictionCurveFrontWheels;
    [SerializeField] float gripMultiplicator = 15.0f;
    [SerializeField] float driftMultiplicatorTest = 15.0f;

    float grip;
    float counterForce;
    Vector3 pointVelocity;


    void Start()
    {
        rb = transform.parent.gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (SuspensionPhysics.isGrounded)
        {
            pointVelocity = rb.GetPointVelocity(transform.position);
            float parallelVelocity = Vector3.Dot(transform.right, pointVelocity);
            float forwardVelocity = Vector3.Dot(transform.forward, pointVelocity);

            if (SuspensionPhysics.isGrounded && frontWheel)
            {
                grip = frictionCurveFrontWheels.Evaluate(parallelVelocity / (parallelVelocity + forwardVelocity));
            }
            else if (SuspensionPhysics.isGrounded && !frontWheel)
            {
                grip = frictionCurveRearWheels.Evaluate(parallelVelocity / (parallelVelocity + forwardVelocity));
            }

            counterForce = -parallelVelocity * grip;
            counterForce = counterForce / Time.fixedDeltaTime;

            rb.AddForceAtPosition(transform.right * counterForce * gripMultiplicator, transform.position);
        }
    }
}
