using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingPhysics : MonoBehaviour
{
    // GameObjects and components
    Rigidbody rb;

    void Start() {
        rb = GetComponent<Rigidbody>();
    }
    void FixedUpdate()
    {
        if (SuspensionPhysics.isGrounded == false) {
            rb.AddForce(-Vector3.up * 15000);
        }
        rb.AddForce(-Vector3.up * 15000);
    }
}
