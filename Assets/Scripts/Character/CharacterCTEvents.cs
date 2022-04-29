/*//////////////////////////////////////////////////////////////////////////////////////////
//      █─▄▄▄▄█▄─█─▄█─▄▄▄─█                                                               //
//      █▄▄▄▄─██─▄▀██─███▀█             Scripts created by Semih Kubilay Çetin            //
//      ▀▄▄▄▄▄▀▄▄▀▄▄▀▄▄▄▄▄▀                                                               //
//////////////////////////////////////////////////////////////////////////////////////////*/
using UnityEngine;

public class CharacterCTEvents : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Item/Air"))
        {
            CharacterManager.Instance.TakeItem(other.gameObject.GetComponent<PickupObject>().pickUpData);
            Destroy(other.gameObject);
        }

        if(other.gameObject.CompareTag("Item/Earth"))
        {
            CharacterManager.Instance.TakeItem(other.gameObject.GetComponent<PickupObject>().pickUpData);
            Destroy(other.gameObject);
        }

        if(other.gameObject.CompareTag("Item/Fire"))
        {
            CharacterManager.Instance.TakeItem(other.gameObject.GetComponent<PickupObject>().pickUpData);
            Destroy(other.gameObject);
        }

        if(other.gameObject.CompareTag("Item/Water"))
        {
            CharacterManager.Instance.TakeItem(other.gameObject.GetComponent<PickupObject>().pickUpData);
            Destroy(other.gameObject);
        }
    }
}
/* Tip    #if UNITY_EDITOR
          Debug.Log("Unity Editor");
          #endif                          Tip End */