/*//////////////////////////////////////////////////////////////////////////////////////////
//      █─▄▄▄▄█▄─█─▄█─▄▄▄─█                                                               //
//      █▄▄▄▄─██─▄▀██─███▀█             Scripts created by Semih Kubilay Çetin            //
//      ▀▄▄▄▄▄▀▄▄▀▄▄▀▄▄▄▄▄▀                                                               //
//////////////////////////////////////////////////////////////////////////////////////////*/
using UnityEngine;

public class Test : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyUp(KeyCode.Alpha1))
        {
            GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterCreateDrops>().GetItemToTarget(transform,PickupType.Air,PickupTier.TierI);
        }
        if(Input.GetKeyUp(KeyCode.Alpha2))
        {
            GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterCreateDrops>().GetItemToTarget(transform,PickupType.Air,PickupTier.TierII);
        }
        if(Input.GetKeyUp(KeyCode.Alpha3))
        {
            GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterCreateDrops>().GetItemToTarget(transform,PickupType.Air,PickupTier.TierIII);
        }

        if(Input.GetKeyUp(KeyCode.Q))
        {
            GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterCreateDrops>().GetItemToTarget(transform,PickupType.Earth,PickupTier.TierI);
        }
        if(Input.GetKeyUp(KeyCode.W))
        {
            GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterCreateDrops>().GetItemToTarget(transform,PickupType.Earth,PickupTier.TierII);
        }
        if(Input.GetKeyUp(KeyCode.E))
        {
            GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterCreateDrops>().GetItemToTarget(transform,PickupType.Earth,PickupTier.TierIII);
        }

        if(Input.GetKeyUp(KeyCode.A))
        {
            GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterCreateDrops>().GetItemToTarget(transform,PickupType.Fire,PickupTier.TierI);
        }
        if(Input.GetKeyUp(KeyCode.S))
        {
            GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterCreateDrops>().GetItemToTarget(transform,PickupType.Fire,PickupTier.TierII);
        }
        if(Input.GetKeyUp(KeyCode.D))
        {
            GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterCreateDrops>().GetItemToTarget(transform,PickupType.Fire,PickupTier.TierIII);
        }

        if(Input.GetKeyUp(KeyCode.Z))
        {
            GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterCreateDrops>().GetItemToTarget(transform,PickupType.Water,PickupTier.TierI);
        }
        if(Input.GetKeyUp(KeyCode.X))
        {
            GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterCreateDrops>().GetItemToTarget(transform,PickupType.Water,PickupTier.TierII);
        }
        if(Input.GetKeyUp(KeyCode.C))
        {
            GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterCreateDrops>().GetItemToTarget(transform,PickupType.Water,PickupTier.TierIII);
        }
    }
}
/* Tip    #if UNITY_EDITOR
          Debug.Log("Unity Editor");
          #endif                          Tip End */