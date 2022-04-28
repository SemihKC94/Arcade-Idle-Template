/*//////////////////////////////////////////////////////////////////////////////////////////
//      █─▄▄▄▄█▄─█─▄█─▄▄▄─█                                                               //
//      █▄▄▄▄─██─▄▀██─███▀█             Scripts created by Semih Kubilay Çetin            //
//      ▀▄▄▄▄▄▀▄▄▀▄▄▀▄▄▄▄▄▀                                                               //
//////////////////////////////////////////////////////////////////////////////////////////*/
using UnityEngine.UI;
using UnityEngine;

public class InventoryVisual : MonoBehaviour
{
    [Header("My Inventory")]
    public InventoryObject myInventory;

    [Header("Use Inventory Item Keys")]
    public KeyCode useSlot1 = KeyCode.Alpha1;
    public KeyCode useSlot2 = KeyCode.Alpha2;
    public KeyCode useSlot3 = KeyCode.Alpha3;
    public KeyCode useSlot4 = KeyCode.Alpha4;
    public KeyCode useSlot5 = KeyCode.Alpha5;
    public KeyCode useSlot6 = KeyCode.Alpha6;

    [Header("Each Item Prefab")]
    public GameObject itemPrefab;

    [Header("Item Container")]
    public RectTransform myInventoryContainer;

    //privat vars
    private int inventoryButtonClick = 0;

    private void Start()
    {
        InventoryUpdate();
    }

    private void Update()
    {
        if(Input.GetKeyUp(useSlot1))
        {
            if(myInventoryContainer.childCount >= 1)
            {
                if (myInventoryContainer.transform.GetChild(0) != null)
                {
                    if (myInventoryContainer.transform.GetChild(0).GetComponent<InventoryVisualPrefab>().useAble)
                    {
                        myInventoryContainer.transform.GetChild(0).GetComponent<InventoryVisualPrefab>().Using();
                        myInventory.DeleteItem(myInventory.Container[0].item, -1);
                        InventoryUpdate();
                    }
                }
            }
            else
            {
#if UNITY_EDITOR
                Debug.Log($"<color=red> Slot Bos</color>");
#endif
            }
        }

        if (Input.GetKeyUp(useSlot2))
        {
            if(myInventoryContainer.childCount >= 2)
            {
                if (myInventoryContainer.transform.GetChild(1))
                {
                    if (myInventoryContainer.transform.GetChild(1).GetComponent<InventoryVisualPrefab>().useAble)
                    {
                        myInventoryContainer.transform.GetChild(1).GetComponent<InventoryVisualPrefab>().Using();
                        myInventory.DeleteItem(myInventory.Container[1].item, -1);
                        InventoryUpdate();
                    }
                }
            }
            else
            {
#if UNITY_EDITOR
                Debug.Log($"<color=red> Slot Bos</color>");
#endif
            }
        }

        if (Input.GetKeyUp(useSlot3))
        {
            if(myInventoryContainer.childCount >= 3)
            {
                if (myInventoryContainer.transform.GetChild(2) != null)
                {
                    if (myInventoryContainer.transform.GetChild(2).GetComponent<InventoryVisualPrefab>().useAble)
                    {
                        myInventoryContainer.transform.GetChild(2).GetComponent<InventoryVisualPrefab>().Using();
                        myInventory.DeleteItem(myInventory.Container[2].item, -1);
                        InventoryUpdate();
                    }
                }
            }
            else
            {
#if UNITY_EDITOR
                Debug.Log($"<color=red> Slot Bos</color>");
#endif
            }
        }

        if (Input.GetKeyUp(useSlot4))
        {
            if(myInventoryContainer.childCount >= 4)
            {
                if (myInventoryContainer.transform.GetChild(3) != null)
                {
                    if (myInventoryContainer.transform.GetChild(3).GetComponent<InventoryVisualPrefab>().useAble)
                    {
                        myInventoryContainer.transform.GetChild(3).GetComponent<InventoryVisualPrefab>().Using();
                        myInventory.DeleteItem(myInventory.Container[3].item, -1);
                        InventoryUpdate();
                    }
                }
            }
            else
            {
#if UNITY_EDITOR
                Debug.Log($"<color=red> Slot Bos</color>");
#endif
            }
        }

        if (Input.GetKeyUp(useSlot5))
        {
            if(myInventoryContainer.childCount >= 5)
            {
                if (myInventoryContainer.transform.GetChild(4) != null)
                {
                    if (myInventoryContainer.transform.GetChild(4).GetComponent<InventoryVisualPrefab>().useAble)
                    {
                        myInventoryContainer.transform.GetChild(4).GetComponent<InventoryVisualPrefab>().Using();
                        myInventory.DeleteItem(myInventory.Container[4].item, -1);
                        InventoryUpdate();
                    }
                }
            }
            else
            {
#if UNITY_EDITOR
                Debug.Log($"<color=red> Slot Bos</color>");
#endif
            }
        }

        if (Input.GetKeyUp(useSlot6))
        {
            if(myInventoryContainer.childCount >= 6)
            {
                if (myInventoryContainer.transform.GetChild(5) != null)
                {
                    if (myInventoryContainer.transform.GetChild(5).GetComponent<InventoryVisualPrefab>().useAble)
                    {
                        myInventoryContainer.transform.GetChild(5).GetComponent<InventoryVisualPrefab>().Using();
                        myInventory.DeleteItem(myInventory.Container[5].item, -1);
                        InventoryUpdate();
                    }
                }
            }
            else
            {
#if UNITY_EDITOR
                Debug.Log($"<color=red> Slot Bos</color>");
#endif
            }
        }
    }

    public void InventoryUpdate()
    {
        for (int i = 0; i < myInventoryContainer.transform.childCount; i++)
        {
            GameObject t = myInventoryContainer.transform.GetChild(i).gameObject;
            Destroy(t.gameObject);
        }

        for (int i = 0; i < myInventory.Container.Count; i++)
        {
            GameObject itemTemp = (GameObject)Instantiate(itemPrefab, myInventoryContainer);
            itemTemp.GetComponent<InventoryVisualPrefab>().SetItem(myInventory.Container[i].item.type, myInventory.Container[i].item.itemValue, myInventory.Container[i].item.itemSprite, myInventory.Container[i].item.description, myInventory.Container[i].amount, myInventory.Container[i].item.useAble);
        }
    }
}

/* Tip    #if UNITY_EDITOR
          Debug.Log("Unity Editor");
          #endif                          Tip End */