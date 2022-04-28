/*//////////////////////////////////////////////////////////////////////////////////////////
//      █─▄▄▄▄█▄─█─▄█─▄▄▄─█                                                               //
//      █▄▄▄▄─██─▄▀██─███▀█             Scripts created by Semih Kubilay Çetin            //
//      ▀▄▄▄▄▄▀▄▄▀▄▄▀▄▄▄▄▄▀                                                               //
//////////////////////////////////////////////////////////////////////////////////////////*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitAction : MonoBehaviour
{
    [Header("Configuration")]
    public float delay = 5f;

    public delegate void ActionExit();
    public static event ActionExit WhenExitChunk;

    //private vars
    private bool exited = false;

    private void OnTriggerExit(Collider other)
    {
        CarTag myCar = other.GetComponent<CarTag>();
        if(myCar != null)
        {
            if(!exited)
            {
                exited = true;
                WhenExitChunk();
                StartCoroutine(Deactivator());
            }
        }
    }

    IEnumerator Deactivator()
    {
        yield return new WaitForSeconds(delay);

        transform.root.gameObject.SetActive(false);
    }
}

/* Tip    #if UNITY_EDITOR
          Debug.Log("Unity Editor");
          #endif                          Tip End */