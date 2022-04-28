using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HeathenEngineering.Events;

public class TriggerSignalSender : MonoBehaviour
{
    [Header("Entered Event")]
    public UnityColliderEvent TriggerEnter;
    [SerializeField] private string enterTag = null;

    [Header("Stay Event")]
    public UnityColliderEvent TriggerStay;
    [SerializeField] private string stayTag = null;

    [Header("Exit Event")]
    public UnityColliderEvent TriggerExit;
    [SerializeField] private string exitTag = null;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag(enterTag)) TriggerEnter.Invoke(other);
        #if UNITY_EDITOR
        Debug.Log($"<color=green>{other.name}</color> entered <color=cyan>{this.gameObject.name}</color>'s trigger area");
        #endif
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.CompareTag(stayTag)) TriggerStay.Invoke(other);
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.CompareTag(exitTag)) TriggerExit.Invoke(other);
    }
}
