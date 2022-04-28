using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickedObject : MonoBehaviour
{
    [Header("Items")]
    [SerializeField] private GameObject[] items;
    [SerializeField] private ParticleSystem[] itemsEffect;

    // Privates
    // Components
    private PickupsSO itemData;

    public void Init(PickupsSO data)
    {
        itemData = data;

        switch (itemData.itemType)
        {
            case PickupType.Air:
                items[0].gameObject.SetActive(true);
                itemsEffect[0].Play();
                transform.tag = itemData.targetTag;
                this.gameObject.name = itemData.targetTag;

                break;

            case PickupType.Earth:
                items[1].gameObject.SetActive(true);
                itemsEffect[1].Play();
                transform.tag = itemData.targetTag;
                this.gameObject.name = itemData.targetTag;

                break;

            case PickupType.Fire:
                items[2].gameObject.SetActive(true);
                itemsEffect[2].Play();
                transform.tag = itemData.targetTag;
                this.gameObject.name = itemData.targetTag;

                break;

            case PickupType.Water:
                items[3].gameObject.SetActive(true);
                itemsEffect[3].Play();
                transform.tag = itemData.targetTag;
                this.gameObject.name = itemData.targetTag;

                break;
        }
    }
}
