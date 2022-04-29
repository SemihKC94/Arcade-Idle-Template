/*//////////////////////////////////////////////////////////////////////////////////////////
//      █─▄▄▄▄█▄─█─▄█─▄▄▄─█                                                               //
//      █▄▄▄▄─██─▄▀██─███▀█             Scripts created by Semih Kubilay Çetin            //
//      ▀▄▄▄▄▄▀▄▄▀▄▄▀▄▄▄▄▄▀                                                               //
//////////////////////////////////////////////////////////////////////////////////////////*/
using UnityEngine;

public class CharacterCreateDrops : MonoBehaviour
{
    [Header("Item Prefab")]
    [SerializeField] private GameObject _itemPrefab = null;
    [SerializeField] private GameObject _goldPrefab = null;
    [SerializeField] private PickupsSO itemData = null;

    public void GetItemToTarget(Transform target,PickupType itemType,PickupTier itemTier)
    {
        GameObject _itemTep = (GameObject)Instantiate(_itemPrefab,transform.position,transform.rotation);
        itemData.itemTier = itemTier;
        itemData.itemType = itemType;
        _itemTep.tag ="Item/"+itemType.ToString();
        _itemTep.GetComponent<PickupObject>().Init(target,itemData);
    }

    public void GetGoldToTarget(Transform target)
    {
        GameObject _itemTep = (GameObject)Instantiate(_goldPrefab,transform.position,transform.rotation);
        _itemTep.GetComponent<PickupObject>().Init(target,true);
    }
}
/* Tip    #if UNITY_EDITOR
          Debug.Log("Unity Editor");
          #endif                          Tip End */