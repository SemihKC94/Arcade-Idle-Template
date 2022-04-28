/*//////////////////////////////////////////////////////////////////////////////////////////
//      █─▄▄▄▄█▄─█─▄█─▄▄▄─█                                                               //
//      █▄▄▄▄─██─▄▀██─███▀█             Scripts created by Semih Kubilay Çetin            //
//      ▀▄▄▄▄▄▀▄▄▀▄▄▀▄▄▄▄▄▀                                                               //
//////////////////////////////////////////////////////////////////////////////////////////*/
using UnityEngine;
using UnityEngine.Events;

public class SKC_EventListener : MonoBehaviour
{
    public SKC_GameEvent myEvent;
    public UnityEvent Response;

    void OnEnable() => myEvent.Register(this);
    void OnDisable() => myEvent.DeRegister(this);

    public void OnEventRaised() => Response.Invoke();
}

/* Tip    #if UNITY_EDITOR
          Debug.Log("Unity Editor");
          #endif                          Tip End */