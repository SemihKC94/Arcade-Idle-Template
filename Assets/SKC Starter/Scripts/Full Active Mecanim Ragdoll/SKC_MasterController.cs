﻿using UnityEngine;


public enum CharacterState
{
    IDLE,
    WALKING,
    RUNNING,
    FALLING
}


public class SKC_MasterController : MonoBehaviour
{
    #region Assignable vars
    [Header("States")]
    public CharacterState state;

    [Space, Header("Configuration")]
    [SerializeField]
    private bool canMove = false;
    [SerializeField]
    private float walkSpeed = 3.0f;
    [SerializeField]
    private float runSpeed = 7.0f;
    [SerializeField]
    private float gravity = 9.81f;
    [SerializeField]
    [Tooltip("Determines how fast character turns.")]
    private float turnSmoothTime = 0.35f;
    [SerializeField]
    [Tooltip("Determines how high will character float above ground.")]
    private float groundDistance = 0.1f;
    [SerializeField]
    [Tooltip("Determines how fast pushed back towards ragdoll.")]
    private float pushBackSpeed = 7.0f;
    [SerializeField]
    [Tooltip("Maximum distance move away from ragdoll.")]
    private float maxPossibleDistanceFromRagdoll = 2.0f;
    [SerializeField]
    [Tooltip("considered to be ground.")]
    private LayerMask groundMask;

    #endregion

    #region Private vars
    private Camera characterCamera;
    private Transform masterRoot;
    private Transform slaveRoot;
    private Animator anim;
    private bool isGrounded;
    private float currentFallVelocity;
    private float currentTurnSmoothVelocity;
    #endregion

    void Start()
    {
        SKC_HumanoidSetUp setUp = this.GetComponentInParent<SKC_HumanoidSetUp>();
        characterCamera = setUp.characterCamera;
        masterRoot = setUp.masterRoot;
        slaveRoot = setUp.slaveRoot;
        anim = setUp.anim;
    }

    void FixedUpdate()
    {
        isGrounded = Physics.CheckSphere(this.transform.position, groundDistance, groundMask);

        state = GetCharacterState();

        if (state != CharacterState.FALLING)
            currentFallVelocity = 0;

        Vector3 direction = GetDirectionFromInput();
        float cameraAngleY = characterCamera.transform.eulerAngles.y;
        float currentCharacterAngle = CalculateCharacterAngle(direction, cameraAngleY);

        SetCharacterRotation(currentCharacterAngle);

        if(canMove)
        {
            Vector3 moveDirection = Quaternion.Euler(0f, currentCharacterAngle, 0f) * Vector3.forward;
            MoveCharacter(moveDirection);
        }

        //SetAnimation();
    }


    private CharacterState GetCharacterState()
    {
        bool WSAD = Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D);
        if (!isGrounded)
        {
            return CharacterState.FALLING;
        }
        else if (WSAD && Input.GetKey(KeyCode.LeftShift))
        {
            return CharacterState.RUNNING;
        }
        else if (WSAD)
        {
            return CharacterState.WALKING;
        }
        else
        {
            return CharacterState.IDLE;
        }
    }

    private Vector3 GetDirectionFromInput()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        return new Vector3(horizontal, 0f, vertical).normalized;
    }

    private float CalculateCharacterAngle(Vector3 direction, float cameraAngleY)
    {
        float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cameraAngleY;
        float characterAngle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref currentTurnSmoothVelocity, turnSmoothTime);

        return characterAngle;
    }

    private void MoveCharacter(Vector3 moveDirection)
    {
        moveDirection = moveDirection.normalized;
        Debug.DrawRay(transform.position, moveDirection * 5, Color.red);

        Vector3 pushBackMovement = CalculatePushBackMovement();
        Vector3 movement = moveDirection + pushBackMovement;

        switch (state)
        {
            case CharacterState.FALLING:
                currentFallVelocity -= gravity * Time.fixedDeltaTime;
                transform.position += new Vector3(0, currentFallVelocity * Time.fixedDeltaTime, 0);
                break;
            case CharacterState.RUNNING:
                transform.position += movement * runSpeed * Time.fixedDeltaTime;
                break;
            case CharacterState.WALKING:
                transform.position += movement * walkSpeed * Time.fixedDeltaTime;
                break;
            case CharacterState.IDLE:
                transform.position += pushBackMovement * pushBackSpeed * Time.fixedDeltaTime;
                break;
            default:
                break;
        }
    }

    private void SetCharacterRotation(float angleY)
    {
        transform.rotation = Quaternion.Euler(0f, angleY, 0f);
    }

    private void SetAnimation()
    {
        switch (state)
        {
            case CharacterState.FALLING:
                break;
            case CharacterState.RUNNING:
                anim.SetInteger("SKC_AnimConfig", 2);
                break;
            case CharacterState.WALKING:
                anim.SetInteger("SKC_AnimConfig", 1);
                break;
            case CharacterState.IDLE:
                anim.SetInteger("SKC_AnimConfig", 0);
                break;
            default:
                break;
        }
    }

    private Vector3 CalculatePushBackMovement()
    {
        Vector3 slaveToMasterVector = (slaveRoot.position - masterRoot.position);
        float distance = slaveToMasterVector.magnitude;

        float ratio = Mathf.Clamp(distance / maxPossibleDistanceFromRagdoll, 0, 1);
        float magnitude = Mathf.SmoothStep(0, 1, ratio);
        Vector3 moveVector = Vector3.ClampMagnitude(slaveToMasterVector, magnitude);

        moveVector.y = 0;
        return moveVector;
    }

}
