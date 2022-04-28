/*//////////////////////////////////////////////////////////////////////////////////////////
//      █─▄▄▄▄█▄─█─▄█─▄▄▄─█                                                               //
//      █▄▄▄▄─██─▄▀██─███▀█             Scripts created by Semih Kubilay Çetin            //
//      ▀▄▄▄▄▄▀▄▄▀▄▄▀▄▄▄▄▄▀                                                               //
//////////////////////////////////////////////////////////////////////////////////////////*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemYeri : MonoBehaviour, IDropHandler
{
    public Transform pTransform;
    public Transform cTransform;
    public void OnDrop(PointerEventData eventData)
    {
        if(eventData.pointerDrag != null)
        {
            if (eventData.pointerDrag.gameObject.transform.tag == transform.tag)
            {
                eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition;
                eventData.pointerDrag.GetComponent<Dragable>().sepette = true;
                Destroy(eventData.pointerDrag.gameObject);
            }
            else
            {
                switch (eventData.pointerDrag.gameObject.transform.tag)
                {
                    case "P":
                        eventData.pointerDrag.GetComponent<RectTransform>().position = pTransform.position;
                        eventData.pointerDrag.GetComponent<Dragable>().sepette = false;
                        break;

                    case "C":
                        eventData.pointerDrag.GetComponent<RectTransform>().position = cTransform.position;
                        eventData.pointerDrag.GetComponent<Dragable>().sepette = false;
                        break;

                        //Kaç tag varsa ona göre case leri arttırıp pozisyonlarını verirsin sepette olan satır diğerlerinde de aynı kalsın
                }
            }
        }

    }
}

/* Tip    #if UNITY_EDITOR
          Debug.Log("Unity Editor");
          #endif                          Tip End */