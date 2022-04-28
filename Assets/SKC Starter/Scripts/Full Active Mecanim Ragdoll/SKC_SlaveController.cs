using UnityEngine;
using System;


public enum RagdollState
{
    FOLLOWING_ANIMATION,
    LOOSING_STRENGTH,
    GAINING_STRENGTH,
    DEAD
}


public class SKC_SlaveController : MonoBehaviour
{
    #region Assignable vars
    [Header("State")]
    public RagdollState state;


    [Space,Header("Configuration")]
    [SerializeField]
    [Tooltip("Determines how fast ragdoll loses weight when in contact.")]
    private float looseStrengthLerp = 1.0f;
    [SerializeField]
    [Tooltip("Determines how fast ragdoll gains weight after from contact.")]
    private float gainStrengthLerp = 0.05f;
    [SerializeField]
    [Tooltip("Minimum force strength during collision.")]
    private float minContactForce = 0.1f;
    [SerializeField]
    [Tooltip("Minimum torque strength during collision.")]
    private float minContactTorque = 0.1f;
    [SerializeField]
    [Tooltip("Time of being dead expressed in seconds passed in sumulation.")]
    private float deadTime = 4.0f;

    #endregion


    #region Private & Nonserialized vars
    private SKC_AnimationFollowing animFollow;
    private float maxTorqueCoefficient;
    private float maxForceCoefficient;
    private float currentDeadStep;
    private float currentStrength;
    [NonSerialized] public int currentNumberOfCollisions;

    #endregion

    void Start()
    {
        SKC_HumanoidSetUp setUp = this.GetComponentInParent<SKC_HumanoidSetUp>();
        animFollow = setUp.animFollow;

        maxForceCoefficient = animFollow.forceCoefficient;
        maxTorqueCoefficient = animFollow.torqueCoefficient;
        currentNumberOfCollisions = 0;
        currentDeadStep = deadTime;
        currentStrength = 1.0f;
    }

    void FixedUpdate()
    {
        animFollow.FollowAnimation();

        state = GetRagdollState();
        switch (state)
        {
            case RagdollState.DEAD:
                currentDeadStep += Time.fixedDeltaTime;
                if (currentDeadStep >= deadTime)
                    ComeAlive();
                break;

            case RagdollState.LOOSING_STRENGTH:
                LooseStrength();
                break;

            case RagdollState.GAINING_STRENGTH:
                GainStrength();
                break;
            
            case RagdollState.FOLLOWING_ANIMATION:
                break;

            default:
                break;
        }
    }
     

    private RagdollState GetRagdollState()
    {
        if (!animFollow.isAlive)
        {
            return RagdollState.DEAD;
        }
        else if (currentNumberOfCollisions != 0)
        {
            return RagdollState.LOOSING_STRENGTH;
        }
        else if (currentStrength < 1)
        {
            return RagdollState.GAINING_STRENGTH;
        }
        else
        {
            return RagdollState.FOLLOWING_ANIMATION;
        }
    }

    private void LooseStrength()
    {
        currentStrength -= looseStrengthLerp * Time.fixedDeltaTime;
        currentStrength = Mathf.Clamp(currentStrength, 0, 1);
        InterpolateStrength(currentStrength);
    }

    private void GainStrength()
    {
        currentStrength += gainStrengthLerp * Time.fixedDeltaTime;
        currentStrength = Mathf.Clamp(currentStrength, 0, 1);
        InterpolateStrength(currentStrength);
    }

    private void InterpolateStrength(float ratio)
    {
        animFollow.forceCoefficient = Mathf.Lerp(minContactForce, maxForceCoefficient, ratio);
        animFollow.torqueCoefficient = Mathf.Lerp(minContactTorque, maxTorqueCoefficient, ratio);
    }

    [ContextMenu("Die")]
    private void Die()
    {
        animFollow.isAlive = false;
        currentDeadStep = 0;
        ResetForces();
    }

    [ContextMenu("Come alive")]
    private void ComeAlive()
    {
        animFollow.isAlive = true;
    }

    [ContextMenu("Reset forces")]
    private void ResetForces()
    {
        animFollow.forceCoefficient = 0f;
        animFollow.torqueCoefficient = 0f;
        currentStrength = 0;
    }

}
