/*//////////////////////////////////////////////////////////////////////////////////////////
//      █─▄▄▄▄█▄─█─▄█─▄▄▄─█                                                               //
//      █▄▄▄▄─██─▄▀██─███▀█             Scripts created by Semih Kubilay Çetin            //
//      ▀▄▄▄▄▄▀▄▄▀▄▄▀▄▄▄▄▄▀                                                               //
//////////////////////////////////////////////////////////////////////////////////////////*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Dragable : MonoBehaviour, IPointerDownHandler, IBeginDragHandler,IEndDragHandler,IDragHandler,IDropHandler
{
    [Header("Canvas")]
    [SerializeField] Canvas canvas = null;

    private RectTransform rectTransform;
    private CanvasGroup canvasGroup;
    public Transform pPosition;
    public Transform cPosition;

    [HideInInspector] public bool sepette = false;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("Sürüklemeye Başla");
        canvasGroup.alpha = .6f;
        canvasGroup.blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        Debug.Log("Sürükleniyor");
        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("Sürükleme Bitti");
        canvasGroup.alpha = 1f;
        canvasGroup.blocksRaycasts = true;
        if (sepette) Debug.Log("Yok olucak");
        else
        {
            switch(transform.tag)
            {
                case "P":
                    rectTransform.position = pPosition.position;
                    break;

                case "C":
                    rectTransform.position = cPosition.position;
                    break;

                //Kaç tag varsa ona göre case leri arttırıp pozisyonlarını verirsin
            }
        }

    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("Mouse " + this.gameObject.name + " objesinin üzerinde");
    }

    public void OnDrop(PointerEventData eventData)
    {
        //
    }
}

/* Tip    #if UNITY_EDITOR
          Debug.Log("Unity Editor");
          #endif                          Tip End */