/*//////////////////////////////////////////////////////////////////////////////////////////
//      █─▄▄▄▄█▄─█─▄█─▄▄▄─█                                                               //
//      █▄▄▄▄─██─▄▀██─███▀█             Scripts created by Semih Kubilay Çetin            //
//      ▀▄▄▄▄▄▀▄▄▀▄▄▀▄▄▄▄▄▀                                                               //
//////////////////////////////////////////////////////////////////////////////////////////*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GatherSource : MonoBehaviour
{
    [Header("Source Type")]
    [SerializeField] private PickupType sourceType = PickupType.Air;

    [Header("Source Config")]
    [SerializeField] private PickupsSO pickupData = null;
    [SerializeField] private GameObject crystalContainer = null;
    [SerializeField] private float gatheringTime = 1f;
    [SerializeField] private int supplyTimerMax = 2;
    [SerializeField] private SpriteRenderer border = null;

    // Privates
    private float gatherTime = 0f;
    private int supplyTimer = 0;
    private bool reSupply = false;

    // Components
    private Transform _player;
    private List<Transform> activeChildCrystal;
    private List<Transform> inActiveChildCrystal;
    private int maxSize;

    private void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player").transform;

        activeChildCrystal = GetListChildrenIsActive();
        inActiveChildCrystal = GetListChildrenIsInActive();

        maxSize = inActiveChildCrystal.Count;

        ReSupplySources();
        CheckField();
    }

    public void Gathering()
    {
        CheckField();
        gatherTime++;

        if(gatherTime >= gatheringTime)
        {
            GatheringSource();
            gatherTime = 0f;
        }
        if(!reSupply) CharacterManager.Instance.SetTargetMining(transform.position,true,true);
    }

    private void GatheringSource()
    {
        if(!reSupply)
        {
            pickupData.itemType = sourceType;
            CharacterManager.Instance.TakeItem(pickupData);
            SoundFXManager.Instance.PlaySound(SoundFXManager.Instance.gather,false);

            activeChildCrystal[0].gameObject.SetActive(false);
            activeChildCrystal = GetListChildrenIsActive();
            inActiveChildCrystal = GetListChildrenIsInActive();    
        }
        else
        {
            //ReSupplySources();
            CharacterManager.Instance.SetTargetMining(transform.position,false,true);
        }
    }

    public void ReSupplySources()
    {
        if(inActiveChildCrystal.Count > 0)
        {
            CheckField();
            if(reSupply)
            {
                StartCoroutine(SupplyTimer());
                inActiveChildCrystal[0].gameObject.SetActive(true);
                activeChildCrystal = GetListChildrenIsActive();
                inActiveChildCrystal = GetListChildrenIsInActive();
            }

            CheckField();
        }

        CharacterManager.Instance.SetTargetMining(transform.position,false,true);
    }

    private void CheckField()
    {
        if(inActiveChildCrystal.Count == maxSize)
        {
            border.color = Color.black;
            reSupply = true;
        } 
        else if(inActiveChildCrystal.Count == 0) 
        {
            border.color = Color.white;
            reSupply = false;
        }
    }

    private IEnumerator SupplyTimer()
    {
        while(supplyTimer < supplyTimerMax)
        {
            supplyTimer++;
            yield return new WaitForSeconds(1f);
        }
        supplyTimer = 0;
        ReSupplySources();
    }

    private List<Transform> GetListChildrenIsActive()
    {
        List<Transform> temp = new List<Transform>();
        temp = crystalContainer.transform.GetChildrenIsActive();

        return temp;
    }

    private List<Transform> GetListChildrenIsInActive()
    {
        List<Transform> temp = new List<Transform>();
        temp = crystalContainer.transform.GetChildrenIsInActive();

        return temp;
    }

}
/* Tip    #if UNITY_EDITOR
          Debug.Log("Unity Editor");
          #endif                          Tip End */