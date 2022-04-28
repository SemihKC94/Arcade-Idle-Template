﻿/*//////////////////////////////////////////////////////////////////////////////////////////
//      █─▄▄▄▄█▄─█─▄█─▄▄▄─█                                                               //
//      █▄▄▄▄─██─▄▀██─███▀█             Scripts created by Semih Kubilay Çetin            //
//      ▀▄▄▄▄▄▀▄▄▀▄▄▀▄▄▄▄▄▀                                                               //
//////////////////////////////////////////////////////////////////////////////////////////*/
using UnityEngine;
using System;


public class SKC_AnimationFollowing : MonoBehaviour
{
    #region Transforms
    private Transform slave;     //(ragdoll)
    private Transform master;    //(static animation)
    private Transform[] slaveTransforms;
    private Transform[] masterTransforms;
    #endregion

    #region Rigidbodies
    private Transform[] slaveRigidTransforms;
    private Transform[] masterRigidTransforms;
    private Vector3[] rigidbodiesPosToCOM;  //relative to center of mass
    #endregion

    #region Joints
    private ConfigurableJoint[] slaveConfigurableJoints;
    private Quaternion[] startLocalRotation;
    private Quaternion[] localToJointSpace;
    private JointDrive jointDrive = new JointDrive();
    #endregion

    #region Must-Haves
    private Vector3[] forceLastError;
    private int numOfRigids;
    [NonSerialized]
    public bool isAlive = true;
    [NonSerialized]
    public float forceCoefficient = 1.0f; //Controls force applied to limbs.
    [NonSerialized]
    public float torqueCoefficient = 1.0f; //Controls torque applied to limbs.

    [Range(0f, 340f)] private float angularDrag = 0f; // Rigidbodies angular drag.
    [Range(0f, 2f)] private float drag = 0.1f; // Rigidbodies drag.
    [Range(0f, 1000f)] private float maxAngularVelocity = 1000f; // Rigidbodies maxAngularVelocity.
    [Range(0f, 10f)] private float jointDamping = 0.6f;

    [Tooltip("Proportional force")]
    [Range(0f, 160f)] public float PForce = 8f;
    [Tooltip("Derivative force")]
    [Range(0f, .064f)] public float DForce = 0.01f;

    [Range(0f, 100f)] public float maxForce = 10f; // Limits the force
    [Range(0f, 10000f)] public float maxJointTorque = 2000f; // Limits the force

    public bool useGravity = true;

    // { Hips, LeftUpLeg, LeftLeg, RightUpLeg, RightLeg, Spine1, LeftArm, LeftForeArm, Head, RightArm, RightForeArm }
    private float[] maxForceProfile = { 1f, 1f, 1f, 1f, 1f, 1f, 1f, 1f, 1f, 1f, 1f };
    private float[] maxJointTorqueProfile = { 1f, 1f, 1f, 1f, 1f, 1f, 1f, 1f, 1f, 1f, 1f };
    private float[] jointDampingProfile = { 1f, 1f, 1f, 1f, 1f, 1f, 1f, 1f, 1f, 1f, 1f };

    private bool[] limbProfile = { true, true, true, true, true, true, true, true, true, true, true }; // False means no force and torque
    #endregion


    void Start()
    {
        SKC_HumanoidSetUp setUp = this.GetComponentInParent<SKC_HumanoidSetUp>();
        master = setUp.masterRoot;
        slave = setUp.slaveRoot;

        slaveTransforms = slave.GetComponentsInChildren<Transform>(); // Get all transforms in ragdoll.
        masterTransforms = master.GetComponentsInChildren<Transform>(); // Get all transforms in master. 

        if (masterTransforms.Length != slaveTransforms.Length)
        {
            Debug.LogWarning("Master transform count does not equal slave transform count." + "\n");
            return;
        }

        numOfRigids = slave.GetComponentsInChildren<Rigidbody>().Length;
        slaveRigidTransforms = new Transform[numOfRigids];
        masterRigidTransforms = new Transform[numOfRigids];
        rigidbodiesPosToCOM = new Vector3[numOfRigids];
        slaveConfigurableJoints = new ConfigurableJoint[numOfRigids];
        startLocalRotation = new Quaternion[numOfRigids];
        localToJointSpace = new Quaternion[numOfRigids];
        forceLastError = new Vector3[numOfRigids];

        int i = 0, j = 0;
        foreach (Transform t in slaveTransforms)
        {
            if (t.GetComponent<Rigidbody>() != null)
            {
                slaveRigidTransforms[i] = t;
                masterRigidTransforms[i] = masterTransforms[j];
                rigidbodiesPosToCOM[i] = Quaternion.Inverse(t.rotation) * (t.GetComponent<Rigidbody>().worldCenterOfMass - t.position);

                ConfigurableJoint cj = t.GetComponent<ConfigurableJoint>();
                if (cj != null) // ragdoll root (hips) doesn't have configurable joint
                {
                    slaveConfigurableJoints[i] = cj;

                    Vector3 forward = Vector3.Cross(cj.axis, cj.secondaryAxis);
                    Vector3 up = cj.secondaryAxis;

                    localToJointSpace[i] = Quaternion.LookRotation(forward, up);
                    startLocalRotation[i] = t.localRotation * localToJointSpace[i];

                    jointDrive = cj.slerpDrive;
                    cj.slerpDrive = jointDrive;
                }
                else if (i != 0) // if it's not root (hips)
                {
                    Debug.LogWarning("Rigidbody " + t + " doesn't have configurable joint" + "\n");
                    return;
                }
                i++;

                t.gameObject.AddComponent<SKC_CollisionDetector>();
            }
            j++;
        }

        foreach (Transform t in slaveRigidTransforms)
        {
            t.GetComponent<Rigidbody>().useGravity = useGravity;
            t.GetComponent<Rigidbody>().angularDrag = angularDrag;
            t.GetComponent<Rigidbody>().drag = drag;
            t.GetComponent<Rigidbody>().maxAngularVelocity = maxAngularVelocity;
        }

        EnableJointLimits(true);
    }

    public void FollowAnimation()
    {

        if (!isAlive)
        {
            SetJointTorque(0, 0);
            return;
        }
        else
        {
            SetJointTorque(maxJointTorque, jointDamping);
        }

        for (int i = 0; i < slaveRigidTransforms.Length; i++) // Do for all rigidbodies of ragdoll
        {
            if (!limbProfile[i]) continue;

            Rigidbody rb = slaveRigidTransforms[i].GetComponent<Rigidbody>();

            // Set rigidbody parameters in real-time
            rb.angularDrag = angularDrag;
            rb.drag = drag;
            rb.maxAngularVelocity = maxAngularVelocity;
            rb.useGravity = useGravity;

            Vector3 masterRigidTransformsWCOM = masterRigidTransforms[i].position + masterRigidTransforms[i].rotation * rigidbodiesPosToCOM[i];     // WCOM = World Center Of Mass
            Vector3 forceError = masterRigidTransformsWCOM - rb.worldCenterOfMass;
            Vector3 forceSignal = PDControl(PForce, DForce, forceError, ref forceLastError[i]);
            forceSignal = Vector3.ClampMagnitude(forceSignal, maxForce * maxForceProfile[i] * forceCoefficient);
            rb.AddForce(forceSignal, ForceMode.VelocityChange);

            if (i != 0) // exclude root (hips)
                slaveConfigurableJoints[i].targetRotation = Quaternion.Inverse(localToJointSpace[i]) * Quaternion.Inverse(masterRigidTransforms[i].localRotation) * startLocalRotation[i];
        }
    }

    private Vector3 PDControl(float P, float D, Vector3 error, ref Vector3 lastError) // A PID controller
    {
        // This is the implemented algorithm:
        Vector3 signal = P * (error + D * (error - lastError) / Time.fixedDeltaTime);
        lastError = error;
        return signal;
    }

    private void SetJointTorque(float positionSpring, float positionDamper)
    {
        for (int i = 1; i < slaveConfigurableJoints.Length; i++) // Do for all configurable joints
        {
            if (!limbProfile[i]) continue;

            jointDrive.positionSpring = positionSpring * maxJointTorqueProfile[i] * torqueCoefficient;
            jointDrive.positionDamper = positionDamper * jointDampingProfile[i];
            slaveConfigurableJoints[i].slerpDrive = jointDrive;
        }
    }

    private void EnableJointLimits(bool jointLimits)
    {
        for (int i = 1; i < slaveConfigurableJoints.Length; i++) // Do for all configurable joints
        {
            if (jointLimits)
            {
                slaveConfigurableJoints[i].angularXMotion = ConfigurableJointMotion.Limited;
                slaveConfigurableJoints[i].angularYMotion = ConfigurableJointMotion.Limited;
                slaveConfigurableJoints[i].angularZMotion = ConfigurableJointMotion.Limited;
            }
            else
            {
                slaveConfigurableJoints[i].angularXMotion = ConfigurableJointMotion.Free;
                slaveConfigurableJoints[i].angularYMotion = ConfigurableJointMotion.Free;
                slaveConfigurableJoints[i].angularZMotion = ConfigurableJointMotion.Free;
            }
        }
    }

}
