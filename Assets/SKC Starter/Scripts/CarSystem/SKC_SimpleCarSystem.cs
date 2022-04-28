/*//////////////////////////////////////////////////////////////////////////////////////////
//      █─▄▄▄▄█▄─█─▄█─▄▄▄─█                                                               //
//      █▄▄▄▄─██─▄▀██─███▀█             Scripts created by Semih Kubilay Çetin            //
//      ▀▄▄▄▄▄▀▄▄▀▄▄▀▄▄▄▄▄▀                                                               //
//////////////////////////////////////////////////////////////////////////////////////////*/
using UnityEngine;

public enum ESPSelect { StrongHandling, MediumHandling, WeakHandling }
public class SKC_SimpleCarSystem : MonoBehaviour
{
    #region Inputs
    [Header("Inputs")]
    public ESPSelect espType = ESPSelect.StrongHandling;
    public float motorPower;
    public float breakForce;
    public float maxSteeringAngle;
    public SKC_ESP espConfiguration;

    [Header("Wheels Configuration")]
    public WheelCollider RRWheelCollider;
    public WheelCollider RLWheelCollider;
    public WheelCollider FRWheelCollider;
    public WheelCollider FLWheelCollider;

    public Transform RRWheelTransform;
    public Transform RLWheelTransform;
    public Transform FRWheelTransform;
    public Transform FLWheelTransform;
    #endregion

    #region Private Vars

    private const string _HORIZONTAL = "Horizontal";
    private const string _VERTICAL = "Vertical";

    private float horizontalInput;
    private float verticalInput;
    private float currentBreakForce;
    private float steerAngle;
    private bool isBreaking;
    #endregion

    #region ESP Configuration
    private void Start()
    {
        ConfigureWheels();
    }

    private void ConfigureWheels()
    {

        switch (espType)
        {
            case ESPSelect.StrongHandling:
                espConfiguration.InitSettings();
                RRWheelCollider.suspensionSpring = espConfiguration.StrongHandling;
                RLWheelCollider.suspensionSpring = espConfiguration.StrongHandling;
                FRWheelCollider.suspensionSpring = espConfiguration.StrongHandling;
                FLWheelCollider.suspensionSpring = espConfiguration.StrongHandling;
                break;

            case ESPSelect.MediumHandling:
                espConfiguration.InitSettings();
                RRWheelCollider.suspensionSpring = espConfiguration.MediumHandling;
                RLWheelCollider.suspensionSpring = espConfiguration.MediumHandling;
                FRWheelCollider.suspensionSpring = espConfiguration.MediumHandling;
                FLWheelCollider.suspensionSpring = espConfiguration.MediumHandling;
                break;

            case ESPSelect.WeakHandling:
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
        TakeInput();
        UseMotor();
        UseSteering();
        UpdateWheels();
    }

    private void TakeInput()
    {
        horizontalInput = Input.GetAxis(_HORIZONTAL);
        verticalInput = Input.GetAxis(_VERTICAL);
        isBreaking = Input.GetKey(KeyCode.Space);
    }
    private void UseMotor()
    {
        FRWheelCollider.motorTorque = verticalInput * motorPower;
        FLWheelCollider.motorTorque = verticalInput * motorPower;

        currentBreakForce = isBreaking ? breakForce : 0f;
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
    #endregion
}

/* Tip    #if UNITY_EDITOR
          Debug.Log("Unity Editor");
          #endif                          Tip End */