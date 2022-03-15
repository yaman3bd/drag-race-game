using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class SpeedMeterUIScript : MonoBehaviour
{
    public TMP_Text CurrentSpeedText;
    public TMP_Text CurrentGearText;

    public Transform CarSpeedLabelTemplete;
    public Transform CarSpeedLabelTempleteParent;

    public Transform SpeedNeedleTransform;

    public float min, max;
    public float currentSpeed;
    public float MaxSpeed;
    public float sMaxSpeed;
    // Start is called before the first frame update
    void Start()
    {
        

    }

    // Update is called once per frame
    void Update()
    {
        currentSpeed += Time.deltaTime * sMaxSpeed;
        SpeedNeedleTransform.localEulerAngles = new Vector3(0, 0, Mathf.Lerp(min, max, currentSpeed / MaxSpeed));
        if (Input.GetKeyDown(KeyCode.Space))
        {
            currentSpeed = 0;
        }
         
    }
}
