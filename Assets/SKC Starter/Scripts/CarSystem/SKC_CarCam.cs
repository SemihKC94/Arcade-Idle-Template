/*//////////////////////////////////////////////////////////////////////////////////////////
//      █─▄▄▄▄█▄─█─▄█─▄▄▄─█                                                               //
//      █▄▄▄▄─██─▄▀██─███▀█             Scripts created by Semih Kubilay Çetin            //
//      ▀▄▄▄▄▄▀▄▄▀▄▄▀▄▄▄▄▄▀                                                               //
//////////////////////////////////////////////////////////////////////////////////////////*/
using UnityEngine;

public class SKC_CarCam : MonoBehaviour
{
    [Header("Cam Configuration")]
    public Transform target = null;
    public Vector3 offSet;
    public float translateSpeed;
    [SerializeField] private float rotationSpeed;
    [SerializeField] private bool isUICam = false;

    private void Update()
    {
        if(target != null)
        {
            HandleTranslation();
            HandleRotation();
        }
    }

    private void HandleTranslation()
    {
        var targetPosition = target.TransformPoint(offSet);
        transform.position = Vector3.Lerp(transform.position, targetPosition, translateSpeed * Time.fixedDeltaTime);
    }

    private void HandleRotation()
    {
        var direction = target.position - transform.position;
        var rotation = Quaternion.LookRotation(isUICam ? direction : -direction, Vector3.up);
        transform.rotation = Quaternion.Lerp(transform.rotation, rotation, rotationSpeed * Time.fixedDeltaTime);
    }

    public void OffSetPot(float x)
    {
        offSet.x = x;
    }
}

/* Tip    #if UNITY_EDITOR
          Debug.Log("Unity Editor");
          #endif                          Tip End */