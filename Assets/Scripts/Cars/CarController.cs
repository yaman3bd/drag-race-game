using GameManagment;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class CarController : MonoBehaviour
{
    public Action OnBoostStarted;
    public Action OnBoostEnded;
    public Action OnDangerZooneStarted;
    public Action OnDangerZooneEned;

    public GameObject BoostEffect;
    public float DistancTravled;
    public WheelCollider[] FrontWheels;
    public WheelCollider[] RearontWheels;
    public WheelCollider[] AllWheels;
    public CarDataScriptableObject CarData;
    public Transform CenterOfMass;

    private bool IsRaceStarted;


    public bool ReachMaxSpeed()
    {

        if (KPH > CarMaxSpeedPerGear[currentGear])
        {
            return true;
        }
        return false;
    }

    public float GetPrevSpeed()
    {
        int prevGear = currentGear - 1;
        if (prevGear == -1)
        {
            return 0;
        }
        return CarMaxSpeedPerGear[prevGear];
    }

    public WheelCollider[] DrivingWheels
    {
        get
        {
            switch (CarData.DrivingType)
            {
                case DrivingTypes.None:
                    Debug.LogError("No driving wheels attached!");
                    Debug.Break();
                    return null;
                case DrivingTypes.Front:
                    return FrontWheels;
                case DrivingTypes.Rear:
                    return RearontWheels;
                case DrivingTypes.All:
                    return AllWheels;
                default:
                    return null;
            }
        }
    }

    int lastGroundCheck = 0;
    private bool isGrounded;
    public bool IsGrounded
    {
        get
        {
            if (lastGroundCheck == Time.frameCount)
                return isGrounded;

            lastGroundCheck = Time.frameCount;
            isGrounded = true;
            foreach (WheelCollider wheel in DrivingWheels)
            {
                if (!wheel.gameObject.activeSelf || !wheel.isGrounded)
                    isGrounded = false;
            }
            return isGrounded;
        }
    }
    public float[] EngineTorques;
    public float GetWheelTorque(int gear)
    {
        float Tw = (CarData.DefaultGearRatio[gear] * CarData.FinalDriveRatio * EngineTorques[gear]) / DrivingWheels.Length;
        return Tw;
    }
    public float GetWheelForce(int gear)
    {
        float Tw = GetWheelTorque(gear) / FrontWheels[0].radius;
        return Tw;
    }
    [Header("Gears")]
    public int currentGear;
    public int CurrentGear
    {
        get { return this.currentGear; }
    }

    public float[] CarMaxSpeedPerGear;

    private float CapSpeedSmoothing;
    public bool AutoGear;

    private float MaxBoostTime
    {
        get
        {
            return CarData.MaxBoostTime;
        }
    }

    private float BoostRefillSpeed
    {
        get
        {
            return CarData.BoostRefillSpeed;
        }
    }
    public float BoostForce;
    private bool isBoosting;
    private bool handbrake;
    private float BrakeForce;
    public bool IsBoosting
    {
        get { return isBoosting; }

        private set { isBoosting = value; }
    }
    private float BoostTime = 10f;

    public float BoostUsedTime;

    private bool BoostAllowed
    {
        get
        {
            return CarData.IsBoostAllowed();
        }
    }
    private float DownForce
    {
        get
        {
            return CarData.DownForce;
        }
    }
    private bool StartAccForceAllowed
    {
        get
        {
            return CarData.IsAddStartAccForceAllowed;
        }
    }
    public float kph;
    public float KPH
    {
        get
        {
            return kph;
        }
    }
    private float StartAccForce
    {
        get
        {
            return CarData.StartAccForce;
        }
    }


    private Rigidbody rb;
    private bool WaitingForGearing;

    private void AddStartAccForce()
    {
        if (StartAccForceAllowed)
        {
            rb.AddForce(transform.forward * StartAccForce * rb.mass, ForceMode.Impulse);

        }
    }
    public void SetCarPosition(float xPos)
    {
        InitialXPos = xPos;
    }
    private void InitCar()
    {
        BrakeForce = 3500;
        rb = GetComponent<Rigidbody>();
        rb.centerOfMass = CenterOfMass.transform.localPosition;
        IsBoosting = false;

        if (CarMaxSpeedPerGear.Length <= 0)
        {
            CarMaxSpeedPerGear = new float[CarData.CarMaxGearsCount];
            float speed = CarData.CarMaxSpeed / CarData.CarMaxGearsCount;


            for (int i = 0; i < CarMaxSpeedPerGear.Length; i++)
            {

                float val = EconomyScript.GetUpgradeLevel(GameManager.Instance.SelectedCarID + "_" + UpgradeTypes.Engine.ToString());
                val = (val / 4) * 80;


                float speedAddedValue = (val / 100) * speed;

                CarMaxSpeedPerGear[i] = (speed + speedAddedValue) * (i + 1);

            }

        }

        if (EngineTorques.Length <= 0)
        {

            EngineTorques = new float[CarData.DefaultEngineTorquesPerGear.Length];

            for (int i = 0; i < EngineTorques.Length; i++)
            {
                float val = EconomyScript.GetUpgradeLevel(GameManager.Instance.SelectedCarID + "_" + UpgradeTypes.Engine.ToString());
                val = (val / 4) * 80;

                float maxSpeed = CarData.DefaultEngineTorquesPerGear[i];
                float speedAddedValue = (val / 100) * maxSpeed;
                EngineTorques[i] = maxSpeed + speedAddedValue;
            }
        }

        float boostadded = EconomyScript.GetUpgradeLevel(GameManager.Instance.SelectedCarID + "_" + UpgradeTypes.Nitro.ToString());
        boostadded = (boostadded / 4) * 80;

        float boostForce = CarData.BoostForce;
        float boostAddedValue = (boostadded / 100) * BoostForce;
        BoostForce = boostForce + boostAddedValue;


        CapSpeedSmoothing = 1.9f;
        LimitRotations = true;
        MaxXRot = 0.55f;
        MaxZRot = 0.25f;

    }
    public float PlayedTime()
    {
        float val = (float)(EndedAtTime - StartedAtTime).TotalSeconds;
        return val;
    }
    public float PlayedSpeed()
    {

        float val = (20 / PlayedTime()) * 100;
        return val;

    }
    public float BoostUsed()
    {
        if (BoostUsedTime==0)
        {
            return 0;
        }
        float val = (7 / BoostUsedTime) * 100;

        return val;
    }

    private bool LimitRotations;
    private float MaxXRot;
    private float MaxZRot;
    public float InitialXPos;

    private void LimitRotation()
    {

        if (!LimitRotations)
        {
            return;
        }

        var rot = transform.rotation;
        rot.x = Mathf.Clamp(rot.x, -MaxXRot, MaxXRot);
        rot.z = Mathf.Clamp(rot.z, -MaxZRot, MaxZRot);

        var a = new Quaternion(0, transform.rotation.y, 0, 1);
        transform.rotation = Quaternion.Slerp(transform.rotation, a, 0.01f);

    }
    private void FreezeTransformPosAndRot(float xPos, float yRot)
    {
        transform.rotation = new Quaternion(transform.rotation.x, yRot, transform.rotation.z, transform.rotation.w);

        transform.position = new Vector3(xPos, transform.position.y, transform.position.z);
    }
    public bool CanGear()
    {
        if (KPH > CarMaxSpeedPerGear[currentGear] && currentGear < CarMaxSpeedPerGear.Length - 1)
        {
            return true;
        }
        return false;
    }
    private void Awake()
    {
        InitCar();
    }

    // Start is called before the first frame update
    void Start()
    {
        BoostTime = MaxBoostTime;
        LoadedLevelManager.Instance.OnRaceEnded += OnRaceEnded;
        LoadedLevelManager.Instance.OnRaceStarted += OnRaceStarted;
        this.OnBoostEnded += BoostEnded_Event;
        this.OnBoostStarted += BoostStarted_Event;

        ToogleHandbrake(true);
        if (BoostEffect)
        {
            BoostEffect.SetActive(false);
        }
        if (AutoGear)
        {
            Destroy(GetComponent<CarAudio>());
            var sounds = GetComponents<AudioSource>();
            foreach (var item in sounds)
            {
                Destroy(item);
            }
        }
    }

    private void BoostStarted_Event()
    {
        if (!BoostEffect)
        {
            return;
        }
        BoostEffect.gameObject.transform.localScale = Vector3.zero;
        BoostEffect.gameObject.SetActive(true);
        BoostEffect.gameObject.transform.DOScale(1, 0.2f);
    }

    private void BoostEnded_Event()
    {
        if (!BoostEffect)
        {
            return;
        }
        BoostEffect.gameObject.transform.DOScale(0, 0.2f).OnComplete(() =>
        {
            BoostEffect.gameObject.SetActive(false);
        }); 
    }

    private void OnRaceStarted()
    {
        IsRaceStarted = true;
        dangerZooneEventCalled = false;
        StartedAtTime = DateTime.Now;
        ToogleHandbrake(false);

    }
    private float TimeToGear;
    const float MaxTimeToGear = 15.0f;
    const float MaxTimeToGearSpeedRange = 3.0f;
    public float GetAvailableTimeToGear()
    {
        return TimeToGear / MaxTimeToGear;
    }
    public float GetTimeToGear()
    {
        return TimeToGear;
    }
 
    private bool dangerZooneEventCalled;
    // Update is called once per frame
    void Update()
    {

        if (!AutoGear && currentGear < CarMaxSpeedPerGear.Length - 1 && this.KPH >= CarMaxSpeedPerGear[currentGear])
        {
            if (!dangerZooneEventCalled)
            {
                dangerZooneEventCalled = true;
                if (OnDangerZooneStarted != null)
                {
                    OnDangerZooneStarted();
                }
            }


            TimeToGear += Time.deltaTime * MaxTimeToGearSpeedRange;
            TimeToGear += UnityEngine.Random.Range(-0.2f, 0.2f);

            if (TimeToGear >= MaxTimeToGear)
            {
                LoadedLevelManager.Instance.EndRace(false);
            }
        }

        if (IsRaceStarted)
        {


            rb.drag = Mathf.Clamp((KPH / CarMaxSpeedPerGear[CarMaxSpeedPerGear.Length - 1]) * 0.075f, 0.001f, 0.075f);

            if (!IsBoosting)
            {
                BoostTime += Time.deltaTime * BoostRefillSpeed;
                if (BoostTime > MaxBoostTime)
                {
                    BoostTime = MaxBoostTime;
                }
            }

            if (CanGear() && AutoGear && !WaitingForGearing && !IsBoosting)
            {
                StartCoroutine(Gear(0.1f));
            }
        }
        LimitRotation();
        FreezeTransformPosAndRot(InitialXPos, 0);
        DistancTravled = transform.position.z;

    }
    IEnumerator Gear(float time)
    {
        WaitingForGearing = true;
        yield return new WaitForSeconds(time);
        ChangeGear(true);
        WaitingForGearing = false;
    }
    public void ChangeGear(bool up)
    {
        if (!IsRaceStarted)
        {
            return;
        }
        if (up)
        {
            TimeToGear = 0;
        }
        if (!AutoGear)
        {
            dangerZooneEventCalled = false;
            if (OnDangerZooneEned != null)
            {
                OnDangerZooneEned();
            }
        }
        if (up)
        {
            currentGear++;

        }
        else
        {
            currentGear--;
        }

        //CarRB.AddForceAtPosition((transform.up * GearUpStuntForce * CarRB.mass), GearStuntForceAt.position, GearStuntForceMode);

        currentGear = Mathf.Clamp(currentGear, 0, CarMaxSpeedPerGear.Length - 1);
    }
    private void OnRaceEnded()
    {
        LoadedLevelManager.Instance.OnRaceEnded -= OnRaceEnded;
        ToogleHandbrake(true);
        rb.drag = 2;
        IsRaceStarted = false;
        EndedAtTime = DateTime.Now;
        InGameUIScript.Instance.EndUI.Show();
        InGameUIScript.Instance.gameObject.SetActive(false);
        /*InGameUIManagerScript.Instance.EndUI.Show();
        InGameUIManagerScript.Instance.Hide();
    */
    }
    private void Drive()
    {
        if (handbrake)
        {
            foreach (WheelCollider wheel in DrivingWheels)
            {
                // Don't zero out this value or the wheel completly lock up
                wheel.motorTorque = 0.0001f;
                wheel.brakeTorque = BrakeForce;
            }
        }
        else
        {
            foreach (var wheel in DrivingWheels)
            {
                wheel.motorTorque = GetWheelTorque(currentGear);
                wheel.brakeTorque = 0;
            }
        }
    }
    public void ToogleHandbrake(bool val)
    {
        handbrake = val;
    }
    private void AddDownForce()
    {
        rb.AddForce(-transform.up * DownForce * rb.velocity.magnitude);
    }
    private bool boostEventCalled;
    public void ActivateBoost()
    {
        // Boost
        if (IsBoosting && BoostAllowed && BoostTime > 0.0f)
        {
            if (!boostEventCalled)
            {
                if (OnBoostStarted != null)
                {
                    OnBoostStarted();
                }
                boostEventCalled = true;
            }

            rb.AddForce(transform.forward * BoostForce);
            //CarRB.AddForceAtPosition((transform.forward * StuntVector.y * CarRB.mass), BoostStuntForceAt.position, BoostStuntForceMode);
            BoostUsedTime += Time.fixedDeltaTime;
            BoostTime -= Time.fixedDeltaTime;
            if (BoostTime < 0f)
            {
                if (OnBoostEnded != null)
                {
                    OnBoostEnded();
                }
                BoostTime = 0f;
                IsBoosting = false;
                boostEventCalled = false;
            }

        }
    }
    private void AutomaticSpeedLimiter()
    {
        Vector3 velocity = Vector3.zero;
        if (KPH > CarMaxSpeedPerGear[currentGear])
        {

            rb.velocity = Vector3.SmoothDamp(rb.velocity, rb.velocity.normalized * (CarMaxSpeedPerGear[currentGear] / 3.6f), ref velocity, CapSpeedSmoothing * Time.deltaTime);
        }
    }
    public float GetAvailableBoost()
    {
        return BoostTime / MaxBoostTime;
    }
    public float GetNormalizedSpeed()
    {
        return KPH / CarMaxSpeedPerGear[currentGear];

    }
    public void ActiveBoost()
    {
        if (!IsRaceStarted)
        {
            return;
        }
        IsBoosting = true;
    }
    private void FixedUpdate()
    {
        Drive();
        ActivateBoost();
        AutomaticSpeedLimiter();
        AddDownForce();
        kph = rb.velocity.magnitude * 3.6f;
    }
    private void AntiRoll()
    {
        WheelHit hit;
        float travelLeft = 1.0f;
        float travelRight = 1.0f;

        bool groundedLeft = FrontWheels[0].GetGroundHit(out hit);
        if (groundedLeft)
        {
            travelLeft = (-FrontWheels[0].transform.InverseTransformPoint(hit.point).y - FrontWheels[0].radius) / FrontWheels[0].suspensionDistance;
        }
        bool groundedRight = FrontWheels[0].GetGroundHit(out hit);
        if (groundedRight)
        {
            travelRight = (-FrontWheels[0].transform.InverseTransformPoint(hit.point).y - FrontWheels[0].radius) / FrontWheels[0].suspensionDistance;
        }

        float rollForce = (travelLeft - travelRight) * 5000.0f;

        rb.AddForceAtPosition(FrontWheels[0].transform.up * -rollForce, FrontWheels[0].transform.position);
    }
    private DateTime StartedAtTime;
    private DateTime EndedAtTime;

}