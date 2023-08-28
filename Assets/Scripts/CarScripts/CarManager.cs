using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarManager : MonoBehaviour
{

    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.R))
        {
            GetComponent<Rigidbody>().velocity = Vector3.zero;
            GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
            transform.position = new Vector3(70f, 2f, 20f);
            transform.rotation = new Quaternion(0f, 0f, 0f, 0f);
        }
    }
}
