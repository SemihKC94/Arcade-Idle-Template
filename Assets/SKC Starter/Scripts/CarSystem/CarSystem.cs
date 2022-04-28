/*//////////////////////////////////////////////////////////////////////////////////////////
//      █─▄▄▄▄█▄─█─▄█─▄▄▄─█                                                               //
//      █▄▄▄▄─██─▄▀██─███▀█             Scripts created by Semih Kubilay Çetin            //
//      ▀▄▄▄▄▄▀▄▄▀▄▄▀▄▄▄▄▄▀                                                               //
//////////////////////////////////////////////////////////////////////////////////////////*/
using System;
using System.Collections;
using UnityEngine;

public enum ESPSelection { StrongHandling, MediumHandling, WeakHandling}
public class CarSystem : MonoBehaviour
{
    #region Inputs
    [Header("Inputs")]
    public ESPSelection espType = ESPSelection.WeakHandling;
    public float motorPower;
    public float breakForce;
    public float maxSteeringAngle;
    public float maxSpeed;
    public float oneWheelCounterForcePower;
    public bool rotCounterForce = false;
    public SKC_ESP espConfiguration;
    public AudioSource engineSound;

    [Header("Wheels Configuration")]
    public WheelCollider RRWheelCollider;
    public WheelCollider RLWheelCollider;
    public WheelCollider FRWheelCollider;
    public WheelCollider FLWheelCollider;

    public Transform RRWheelTransform;
    public Transform RLWheelTransform;
    public Transform FRWheelTransform;
    public Transform FLWheelTransform;

    [Space, Header("Touch Input")] [SerializeField] private Joystick joyStick = null;
    #endregion

    #region Private Vars && NonSerialize

    private const string _HORIZONTAL = "Horizontal";
    private const string _VERTICAL = "Vertical";

    private float horizontalInput = 1f;
    private float verticalInput = 1f;
    private float currentSpeed;
    private float currentBreakForce;
    private float steerAngle;
    private float breakForceHolder = 0f;
    private bool isBreaking;
    private Rigidbody rb;
    [NonSerialized]public bool frOnGround = false, flOnGround = false, rrOnGround = false, rlOnGround = false;
    #endregion

    #region ESP Configuration
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        ConfigureWheels();
        StartCoroutine(FirstStart());
    }

    private IEnumerator FirstStart()
    {
        float hpHolder = motorPower;
        float fstartP = motorPower * .75f;
        motorPower = fstartP;
        yield return new WaitForSeconds(4f);
        motorPower = hpHolder;

    }

    private void ConfigureWheels()
    {

        switch(espType)
        {
            case ESPSelection.StrongHandling:
                espConfiguration.InitSettings();
                RRWheelCollider.suspensionSpring = espConfiguration.StrongHandling;
                RLWheelCollider.suspensionSpring = espConfiguration.StrongHandling;
                FRWheelCollider.suspensionSpring = espConfiguration.StrongHandling;
                FLWheelCollider.suspensionSpring = espConfiguration.StrongHandling;
                break;

            case ESPSelection.MediumHandling:
                espConfiguration.InitSettings();
                RRWheelCollider.suspensionSpring = espConfiguration.MediumHandling;
                RLWheelCollider.suspensionSpring = espConfiguration.MediumHandling;
                FRWheelCollider.suspensionSpring = espConfiguration.MediumHandling;
                FLWheelCollider.suspensionSpring = espConfiguration.MediumHandling;
                break;

            case ESPSelection.WeakHandling:
                espConfiguration.InitSettings();
                RRWheelCollider.suspensionSpring = espConfiguration.WeakHandling;
                RLWheelCollider.suspensionSpring = espConfiguration.WeakHandling;
                FRWheelCollider.suspensionSpring = espConfiguration.WeakHandling;
                FLWheelCollider.suspensionSpring = espConfiguration.WeakHandling;
                break;
        }
    }
    #endregion

    #region Core
    private void FixedUpdate()
    {
        EngineSound();
        TakeInput();
        UseMotor();
        UseSteering();
        UpdateWheels();
        if(rotCounterForce)CounterRotationForce();
    }

    private void CounterRotationForce()
    {
        if(!frOnGround && !rrOnGround && flOnGround && rlOnGround)
        {
            rb.AddRelativeTorque(transform.forward * -oneWheelCounterForcePower);
        }
        if(!flOnGround && !rlOnGround && frOnGround && rrOnGround)
        {
            rb.AddRelativeTorque(transform.forward * oneWheelCounterForcePower);
        }
    }

    private void EngineSound()
    {
        currentSpeed = rb.velocity.magnitude * 3.6f;
        engineSound.pitch = currentSpeed / 100f;
    }
    private void TakeInput()
    {
        horizontalInput = joyStick.Horizontal;
  
        isBreaking = Input.GetKey(KeyCode.Space);
    }
    private void UseMotor()
    {
        if(rb.velocity.magnitude < maxSpeed)
        {
            FRWheelCollider.motorTorque = verticalInput * motorPower;
            FLWheelCollider.motorTorque = verticalInput * motorPower;
        }
        else
        {
            FRWheelCollider.motorTorque = 0f;
            FLWheelCollider.motorTorque = 0f;
        }

        currentBreakForce = isBreaking ? breakForce : breakForceHolder;
        ApplyBreaking();
    }

    private void ApplyBreaking()
    {
        RRWheelCollider.brakeTorque = currentBreakForce;
        RLWheelCollider.brakeTorque = currentBreakForce;
        FRWheelCollider.brakeTorque = currentBreakForce;
        FLWheelCollider.brakeTorque = currentBreakForce;
    }

    private void UseSteering()
    {
        steerAngle = maxSteeringAngle * horizontalInput;
        FLWheelCollider.steerAngle = steerAngle;
        FRWheelCollider.steerAngle = steerAngle;

    }

    private void UpdateWheels()
    {
        UpdateSingleWheel(FLWheelCollider, FLWheelTransform);
        UpdateSingleWheel(FRWheelCollider, FRWheelTransform);
        UpdateSingleWheel(RLWheelCollider, RLWheelTransform);
        UpdateSingleWheel(RRWheelCollider, RRWheelTransform);
    }

    private void UpdateSingleWheel(WheelCollider wheelCollider, Transform wheelTransform)
    {
        Vector3 pos;
        Quaternion rot;
        wheelCollider.GetWorldPose(out pos, out rot);
        wheelTransform.rotation = rot;
        wheelTransform.position = pos;
    }

    public void EmergencyStop()
    {
        breakForceHolder = breakForce * 5f;
    }
    #endregion
}

/* Tip    #if UNITY_EDITOR
          Debug.Log("Unity Editor");
          #endif                          Tip End */