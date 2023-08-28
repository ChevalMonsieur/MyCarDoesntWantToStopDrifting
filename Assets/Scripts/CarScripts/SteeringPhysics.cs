using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SteeringPhysics : MonoBehaviour
{
    // GameObjects and components
    Rigidbody rb;

    // variables
    [SerializeField] float maxSteeringAngle = 30.0f;
    [SerializeField] float steeringSpeed = 60.0f;
    float maxSteeringAngleRadians;
    float maxContextualSteeringAngle;

    void Start()
    {
        rb = transform.parent.gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        maxContextualSteeringAngle = maxSteeringAngle / rb.velocity.magnitude * 30;
        if (maxContextualSteeringAngle > maxSteeringAngle) {
            maxContextualSteeringAngle = maxSteeringAngle;
        }
        maxSteeringAngleRadians = maxContextualSteeringAngle * Mathf.PI / 360;


        Debug.DrawRay(transform.position, transform.forward * 3, Color.green);
        
        if (Input.GetKey(KeyCode.Q) || Input.GetKey(KeyCode.LeftArrow))
        {
            transform.RotateAround(transform.position, transform.up, -steeringSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            transform.RotateAround(transform.position, transform.up, steeringSpeed * Time.deltaTime);
        } else if (!Input.GetKey(KeyCode.Q) && !Input.GetKey(KeyCode.LeftArrow) && !Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.RightArrow)) {
            transform.localRotation = Quaternion.Lerp(transform.localRotation, Quaternion.Euler(transform.rotation.x, 0, transform.localRotation.z), 0.2f);
        }
        if (transform.localRotation.y > maxSteeringAngleRadians) {
            transform.localRotation = Quaternion.Euler(0, maxContextualSteeringAngle, 0);
        } else if (transform.localRotation.y < -maxSteeringAngleRadians) {
            transform.localRotation = Quaternion.Euler(0, -maxContextualSteeringAngle, 0);
        }
    }
}
