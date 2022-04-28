/*//////////////////////////////////////////////////////////////////////////////////////////
//      █─▄▄▄▄█▄─█─▄█─▄▄▄─█                                                               //
//      █▄▄▄▄─██─▄▀██─███▀█             Scripts created by Semih Kubilay Çetin            //
//      ▀▄▄▄▄▄▀▄▄▀▄▄▀▄▄▄▄▄▀                                                               //
//////////////////////////////////////////////////////////////////////////////////////////*/
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class InventoryVisualPrefab : MonoBehaviour
{
    [Header("Child Props")]
    public Image itemSprite;
    public TextMeshProUGUI itemDescription;
    public TextMeshProUGUI itemAmount;
    public bool useAble;

    private float iValue;
    private ItemType myType;

    public void SetItem(ItemType type,float val,Sprite iSprite, string description,int amount,bool useable)
    {
        itemSprite.sprite = iSprite;
        itemDescription.SetText(description);
        itemAmount.SetText(amount.ToString());
        useAble = useable;
        myType = type;

        switch(type)
        {
            case ItemType.Cell:
                iValue = val;

                break;

            case ItemType.Potion:
                iValue = val;

                break;
        }
    }

    public void Using()
    {
        switch(myType)
        {
            case ItemType.Cell:
                // Batarya sc ne göndereceğin değer
                // ornek singleton ise => batarya.Instance.TakeCell(iValue);
#if UNITY_EDITOR
                Debug.Log($"<color=cyan> Batarya {iValue} değerinde arttı</color>");
#endif
                break;

            case ItemType.Potion:
                // Can yada Stamina sc ne göndereceğin değer
                // ornek singleton ise => PlayerHealth.Instance.TakeHealth(iValue);
#if UNITY_EDITOR
                Debug.Log($"<color=green> Canın {iValue} değerinde arttı</color>");
#endif
                break;
        }
    }
}

/* Tip    #if UNITY_EDITOR
          Debug.Log("Unity Editor");
          #endif                          Tip End */