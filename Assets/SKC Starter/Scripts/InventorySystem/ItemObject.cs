/*//////////////////////////////////////////////////////////////////////////////////////////
//      █─▄▄▄▄█▄─█─▄█─▄▄▄─█                                                               //
//      █▄▄▄▄─██─▄▀██─███▀█             Scripts created by Semih Kubilay Çetin            //
//      ▀▄▄▄▄▄▀▄▄▀▄▄▀▄▄▄▄▄▀                                                               //
//////////////////////////////////////////////////////////////////////////////////////////*/
using UnityEngine.UI;
using UnityEngine;

public enum ItemType { Potion,Equipment,Cell}
public abstract class ItemObject : ScriptableObject
{
    [Header("Item Type")]
    public ItemType type;

    [Header("Item Prefab")]
    public GameObject prefab;

    [Header("Item Useable")]
    public bool useAble;

    [Header("Item Value")]
    public float itemValue;

    [Header("Item Image")]
    public Sprite itemSprite;

    [Header("Item Description")]
    [TextArea(10, 20)] public string description;
}

/* Tip    #if UNITY_EDITOR
          Debug.Log("Unity Editor");
          #endif                          Tip End */