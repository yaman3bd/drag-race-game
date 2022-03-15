using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class AntiRoll : MonoBehaviour
{
    private Rigidbody rb;
    public WheelCollider WheelLeft;
    public WheelCollider WheelRight;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();

        Transform wheelsParent = transform.Find("Wheels");
        if (wheelsParent)
        {

            //get wheel colliders
            WheelCollider[] wheelColliders = wheelsParent.GetComponentsInChildren<WheelCollider>();
            WheelLeft = wheelColliders.Where(wheel => wheel.name.Contains("Front")).ToArray()[0];
            WheelRight = wheelColliders.Where(wheel => wheel.name.Contains("Rear")).ToArray()[0];
         }


    }
    private void _AntiRoll()
    {
        WheelHit hit;
        float travelLeft = 1.0f;
        float travelRight = 1.0f;

        bool groundedLeft = WheelLeft.GetGroundHit(out hit);
        if (groundedLeft)
        {
            travelLeft = (-WheelLeft.transform.InverseTransformPoint(hit.point).y - WheelLeft.radius) / WheelLeft.suspensionDistance;
        }
        
        bool groundedRight = WheelRight.GetGroundHit(out hit);
        if (groundedRight)
        {
            travelRight = (-WheelRight.transform.InverseTransformPoint(hit.point).y - WheelRight.radius) / WheelRight.suspensionDistance;
        }

        float rollForce = (travelLeft - travelRight) * 5000.0f;

        if (groundedLeft)
            rb.AddForceAtPosition(WheelLeft.transform.up * -rollForce, WheelLeft.transform.position);

        if (groundedRight)
            rb.AddForceAtPosition(WheelRight.transform.up * rollForce, WheelRight.transform.position);

    }

    private void FixedUpdate()
    {
        _AntiRoll();
    }
}
