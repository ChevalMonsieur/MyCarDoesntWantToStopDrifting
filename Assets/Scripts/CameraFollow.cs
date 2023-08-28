using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    // variables
    GameObject car;
    void Start()
    {
        car = GameObject.Find("NewCar");

    }

    void Update()
    {
        // transform.LookAt(car.transform);
        transform.rotation = car.transform.rotation;
        transform.Rotate(20, 20, 0);
        transform.position = car.transform.position - car.transform.forward * 20 + car.transform.up * 15 - car.transform.right * 20;
    }
}
