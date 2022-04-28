/*//////////////////////////////////////////////////////////////////////////////////////////
//      █─▄▄▄▄█▄─█─▄█─▄▄▄─█                                                               //
//      █▄▄▄▄─██─▄▀██─███▀█             Scripts created by Semih Kubilay Çetin            //
//      ▀▄▄▄▄▄▀▄▄▀▄▄▀▄▄▄▄▄▀                                                               //
//////////////////////////////////////////////////////////////////////////////////////////*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SKC;
using SKC.Utils;

public class UseMyLibrary : MonoBehaviour
{
    public GameObject gateTop;
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Trigger")
        {
            SKC_Debug.TextPopup("This is test", transform.position,transform.rotation,20,Color.white,1f);
            SKC_Tween.TweenCurveAndLoop(gateTop, Vector3.up * 10, 1f,LeanTweenType.easeInOutQuad,true,1);
        }
    }
}

/* Tip    #if UNITY_EDITOR
          Debug.Log("Unity Editor");
          #endif                          Tip End */