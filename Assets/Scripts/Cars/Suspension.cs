using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Suspension : MonoBehaviour
{

    public Transform wheelMeshe;
    public WheelCollider wheelCollider;
    public Vector3 localRotOffset;


    private float lastUpdate;

    void Start()
    {
        lastUpdate = Time.realtimeSinceStartup;
    }

    void FixedUpdate()
    {
        // We don't really need to do this update every time, keep it at a maximum of 60FPS
        if (Time.realtimeSinceStartup - lastUpdate < 1f / 60f)
        {
            return;
        }

        lastUpdate = Time.realtimeSinceStartup;

        if (wheelMeshe && wheelCollider)
        {

            Vector3 pos = new Vector3(0, 0, 0);

            Quaternion quat = new Quaternion();

            wheelCollider.GetWorldPose(out pos, out quat);

            wheelMeshe.rotation = quat;
            wheelMeshe.transform.localRotation *= Quaternion.Euler(localRotOffset);

            wheelMeshe.position = pos;

            /*
            WheelHit wheelHit;

            _wheelCollider.GetGroundHit(out wheelHit);
         
             */
        }
    }
}
