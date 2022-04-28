/*//////////////////////////////////////////////////////////////////////////////////////////
//      █─▄▄▄▄█▄─█─▄█─▄▄▄─█                                                               //
//      █▄▄▄▄─██─▄▀██─███▀█             Scripts created by Semih Kubilay Çetin            //
//      ▀▄▄▄▄▄▀▄▄▀▄▄▀▄▄▄▄▄▀                                                               //
//////////////////////////////////////////////////////////////////////////////////////////*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="SKC_GameEvent",menuName ="SKC_Data/Event")]
public class SKC_GameEvent : ScriptableObject
{
    List<SKC_EventListener> eventListener = new List<SKC_EventListener>();

    public void Raise()
    {
        for (int i = 0; i < eventListener.Count; i++)
        {
            eventListener[i].OnEventRaised();
        }
    }

    public void Register(SKC_EventListener listener)
    {
        if(!eventListener.Contains(listener))
        {
            eventListener.Add(listener);
        }
    }

    public void DeRegister(SKC_EventListener listener)
    {
        if(eventListener.Contains(listener))
        {
            eventListener.Remove(listener);
        }
    }
}

/* Tip    #if UNITY_EDITOR
          Debug.Log("Unity Editor");
          #endif                          Tip End */