using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelPositionning : MonoBehaviour
{
    // GameObjects and components
    SuspensionPhysics suspensionPhysics;

    // variables
    [SerializeField] AnimationCurve flyingWheelsPositionCurve;

    bool groundedLastFrame = true;
    float timeFlying = 0f;
    float positionBeforeFlight = -2;


    void Start()
    {
        transform.localPosition = new Vector3(0, -1, 0);
        suspensionPhysics = transform.parent.gameObject.GetComponent<SuspensionPhysics>();
    }

    void FixedUpdate()
    {
        if (SuspensionPhysics.isGrounded) {
            transform.localPosition = new Vector3(0, -suspensionPhysics.GetSpringLength(), 0);
            if (transform.localPosition.y < -2) {
                transform.localPosition = new Vector3(0, -2, 0);
            }
            positionBeforeFlight = transform.localPosition.y;
            timeFlying = 0f;
        } else {
            if (groundedLastFrame) {
                transform.localPosition = new Vector3(0, -positionBeforeFlight, 0);
                groundedLastFrame = false;
            } else {
                transform.localPosition = new Vector3(0, flyingWheelsPositionCurve.Evaluate(timeFlying) * (positionBeforeFlight + 2)-2, 0);
            }
            timeFlying += Time.fixedDeltaTime;
        }
    }
}
