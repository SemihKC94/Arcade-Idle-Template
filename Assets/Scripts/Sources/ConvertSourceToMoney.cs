using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConvertSourceToMoney : MonoBehaviour
{
    [Header("Collect Config")]
    [SerializeField] private PickupType sourceType = PickupType.Air;
    [SerializeField] private float collectTime = 1;
    [SerializeField] private int _money = 1;

    // Privates
    private float wasteTime = 0;
    public void Collect()
    {
        wasteTime++;

        if(wasteTime >= collectTime)
        {
            CollectSources();
            wasteTime = 0;
        }

        if(CharacterManager.Instance.ReturnListCount(sourceType) > 0) CharacterManager.Instance.SetTargetMining(transform.position,true,false);
        else CharacterManager.Instance.SetTargetMining(Vector3.zero,false,false);
    }

    private void CollectSources()
    {
        if(CharacterManager.Instance.ReturnListCount(sourceType) > 0)
        {
            SoundFXManager.Instance.PlaySound(SoundFXManager.Instance.pickUp);
            CharacterManager.Instance.GiveItem(sourceType);
            CharacterManager.Instance.GetMoney(_money,true);
        }
    }

    public void ExitTrigger()
    {
        CharacterManager.Instance.SetTargetMining(Vector3.zero,false,false);
    }
}
