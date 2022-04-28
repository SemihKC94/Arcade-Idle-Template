using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterManager : MonoBehaviour
{
    // Privates
    // Components
    private CharacterCreateDrops charDrop;
    private CharacterItemContainer charItemList;
    private CharacterMiningBall miningBall;

#region Singleton Pattern
    public static CharacterManager Instance {get; private set;}

    private void Awake()
    {
        Instance = this;
    }
#endregion

#region Unity Methods

    private void Start()
    {
        charDrop = GetComponent<CharacterCreateDrops>();
        charItemList = GetComponent<CharacterItemContainer>();
        miningBall = GetComponent<CharacterMiningBall>();
    }

#endregion

#region Public Methods

    public int MoneyAmount()
    {
        return (int)GameManager.SaveData.SoftCurrency;
    }
    public void GetMoney(int amount, bool popUp)
    {
        GameManager.SaveData.SoftCurrency += amount;

        if(popUp) GUIController.Instance.MoneyPopUp(amount);

        EventBroker.InvokeSave();
        EventBroker.UpdateMoney();
    }

    public void GetGoldFromChar(Transform target)
    {
        charDrop.GetGoldToTarget(target);
    }

    public void TakeItem(PickupsSO data)
    {
        charItemList.AddList(data);
    }

    public void GiveItem(PickupType sourceType)
    {
        charItemList.RemoveList(sourceType);
    }

    public void SetTargetMining(Vector3 target, bool start, bool which)
    {
        miningBall.AssingTarget(target,start,which);
    }

    public int ReturnListCount(PickupType sourceType)
    {
        return charItemList.ListCount(sourceType);
    }

#endregion
}
