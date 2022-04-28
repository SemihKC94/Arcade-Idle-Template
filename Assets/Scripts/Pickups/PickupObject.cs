using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupObject : MonoBehaviour
{   
    [SerializeField] private bool isGold = false;
    // Privates
    // Components
    public PickupsSO pickUpData = null;
    private FlyerObject router;

    private void Awake()
    {
        router = GetComponent<FlyerObject>();
    }
    public void Init(Transform target, PickupsSO itemData)
    {
        pickUpData = itemData;
        switch (pickUpData.itemType)
        {
            case PickupType.Air:
                GameObject airItemClone = (GameObject)Instantiate(itemData.itemAir,transform);
                transform.tag = itemData.targetTag;
                this.gameObject.name = itemData.targetTag;

                break;

            case PickupType.Earth:
                GameObject earthItemClone = (GameObject)Instantiate(itemData.itemEarth,transform);
                transform.tag = itemData.targetTag;
                this.gameObject.name = itemData.targetTag;

                break;

            case PickupType.Fire:
                GameObject fireItemClone = (GameObject)Instantiate(itemData.itemFire,transform);
                transform.tag = itemData.targetTag;
                this.gameObject.name = itemData.targetTag;

                break;

            case PickupType.Water:
                GameObject waterItemClone = (GameObject)Instantiate(itemData.itemWater,transform);
                transform.tag = itemData.targetTag;
                this.gameObject.name = itemData.targetTag;

                break;
        }

        router.FlyToTarget(target,true,0f,pickUpData);
    }

    public void Init(Transform target, bool isGold)
    {
        router.FlyToTarget(target,true,0f,pickUpData);
    }
}
