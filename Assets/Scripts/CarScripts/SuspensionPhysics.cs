using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuspensionPhysics : MonoBehaviour
{
    // GameObjects and components
    Rigidbody rb;

    // variables
    [SerializeField] float restLength = 0.8f;
    [SerializeField] float springTravel = 0.3f;
    [SerializeField] float springStiffness = 33000f;
    [SerializeField] float wheelRadius = 0.9f;
    [SerializeField] float damperStiffness;

    float maxLength;
    float minLength;
    float lastLength;
    float springLength;
    float springForce;
    float springVelocity;
    float damperForce;

    public static bool isGrounded;
    public static Vector3 suspensionPoint;

    Vector3 suspensionForce;

    void Start()
    {
        rb = transform.parent.gameObject.GetComponent<Rigidbody>();
        maxLength = restLength + springTravel;
        minLength = restLength - springTravel;
    }

    void FixedUpdate()
    {

        Debug.DrawRay(transform.position, -transform.up * (maxLength + wheelRadius), Color.yellow);
        Debug.DrawRay(transform.position, -transform.up * (minLength + wheelRadius), Color.red);

        if (Physics.Raycast(transform.position, -transform.up, out RaycastHit hit, maxLength + wheelRadius))
        {
            isGrounded = true;
            lastLength = springLength;
            springLength = hit.distance - wheelRadius;

            springLength = Mathf.Clamp(springLength, minLength, maxLength);
            springForce = springStiffness * (restLength - springLength);
            springVelocity = (lastLength - springLength) / Time.fixedDeltaTime;
            damperForce = damperStiffness * springVelocity;
            suspensionForce = (springForce + damperForce) * transform.up;
            rb.AddForceAtPosition(suspensionForce, hit.point);
        } else {
            isGrounded = false;
        }
    }

    public float GetSpringLength() {
        return springLength;
    }
}
