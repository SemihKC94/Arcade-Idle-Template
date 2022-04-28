using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MoneyPopUp : MonoBehaviour,SKC_IPooledObj
{
    public void OnObjectSpawn()
    {
        RectTransform myTransform = GetComponent<RectTransform>();
        TextMeshProUGUI myText = GetComponent<TextMeshProUGUI>();

        myText.text = "";
        myTransform.anchoredPosition = Vector3.zero;
    }

    public void SetConfig(string text,bool plus, RectTransform target)
    {
        RectTransform myTransform = GetComponent<RectTransform>();
        TextMeshProUGUI myText = GetComponent<TextMeshProUGUI>();
        myText.SetText(text);

        if(!plus)
        {
            myTransform.anchoredPosition = target.anchoredPosition - (new Vector2(-50f,90f));
            LeanTween.moveLocalY(this.gameObject,target.anchoredPosition.y - 200f,.5f).setOnComplete(() => gameObject.SetActive(false));
        }
        else
        {
            myTransform.anchoredPosition = target.anchoredPosition - (new Vector2(-50f,200f));
            LeanTween.moveLocalY(this.gameObject,target.anchoredPosition.y - 90f,.5f).setOnComplete(() => gameObject.SetActive(false));
        }
    }
}
