/*//////////////////////////////////////////////////////////////////////////////////////////
//      █─▄▄▄▄█▄─█─▄█─▄▄▄─█                                                               //
//      █▄▄▄▄─██─▄▀██─███▀█             Scripts created by Semih Kubilay Çetin            //
//      ▀▄▄▄▄▄▀▄▄▀▄▄▀▄▄▄▄▄▀                                                               //
//////////////////////////////////////////////////////////////////////////////////////////*/
using UnityEngine;
using System;


public class SKC_HumanoidSetUp : MonoBehaviour
{

    #region Assignable vars
    [Tooltip("Static animator hips.")]
    public Transform masterRoot;
    [Tooltip("Ragdoll hips.")]
    public Transform slaveRoot;
    [Tooltip("Camera following the character.")]
    public Camera characterCamera;
    [Tooltip("Ragdoll looses strength when colliding with other objects except for objects with layers contained in this mask.")]
    public LayerMask dontLooseStrengthLayerMask;

    #endregion


    #region NonSerialized Accesable var
    [NonSerialized]
    public SKC_MasterController masterController;
    [NonSerialized]
    public SKC_SlaveController slaveController;
    [NonSerialized]
    public SKC_AnimationFollowing animFollow;
    [NonSerialized]
    public Animator anim;

    #endregion
    void Awake()
    {
        if (masterRoot == null) Debug.LogError("masterRoot not assigned.");
        if (slaveRoot == null) Debug.LogError("slaveRoot not assigned.");
        if (characterCamera == null) Debug.LogError("characterCamera not assigned.");

        masterController = this.GetComponentInChildren<SKC_MasterController>();
        if (masterController == null) Debug.LogError("MasterControler not found.");

        slaveController = this.GetComponentInChildren<SKC_SlaveController>();
        if (slaveController == null) Debug.LogError("SlaveController not found.");

        animFollow = this.GetComponentInChildren<SKC_AnimationFollowing>();
        if (animFollow == null) Debug.LogError("AnimationFollowing not found.");

        anim = this.GetComponentInChildren<Animator>();
        if (anim == null) Debug.LogError("Animator not found.");
    }

}
