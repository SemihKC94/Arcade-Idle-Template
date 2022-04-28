using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterItemContainer : MonoBehaviour
{
    [Header("Item List")]
    public List<GameObject> itemContaier;

    [Header("Item Prefab")]
    [SerializeField] private GameObject _itemPrefab = null;

    [Header("Item Container")]
    [SerializeField] private Transform _itemContainer = null;

    [Header("Item Order Config")]
    [SerializeField] private Vector2 betweenSpace = new Vector2(.2f,.2f);

    [Header("Test data")]
    public PickupsSO testData;

#region Unity Methods
    private void Start()
    {
        itemContaier = new List<GameObject>();
    }

#endregion

#region Public Methods

    public void AddList(PickupsSO data)
    {
        GameObject itemTemp = (GameObject)Instantiate(_itemPrefab,_itemContainer);
        itemTemp.GetComponent<PickedObject>().Init(data);
        if(!itemContaier.Contains(itemTemp))
        {
            itemContaier.Add(itemTemp);
        }

        OrderList();
    }

    public void RemoveList(PickupType sourceType)
    {
        if(itemContaier.Count > 0)
        {
            GameObject temp = null;
            foreach (var item in itemContaier)
            {
                if(item.name == "Item/" + sourceType.ToString())
                {
                    temp = item;
                }
            }

            if(temp != null)
            {
                itemContaier.Remove(temp);
                Destroy(temp);
                OrderList();
            }
        }
    }

    public int ListCount(PickupType sourceType)
    {
        int typeCount = 0;
        foreach (var item in itemContaier)
        {
            if(item.name == "Item/" + sourceType.ToString())
            {
                typeCount++;
            }
        }
        return typeCount;
    }

#endregion

#region Private Methods
    
    private void OrderList()
    {
        int yMultiply = 1;
        for (int i = 0; i < itemContaier.Count; i++)
        {
            switch(i % 2)
            {
                case 0:
                    itemContaier[i].transform.localPosition = new Vector3(0f,betweenSpace.y * yMultiply,0f);
                    break;

                case 1:
                    itemContaier[i].transform.localPosition = new Vector3(betweenSpace.x,betweenSpace.y * yMultiply,0f);
                    yMultiply++;
                    break;
            }
        }
    }

    [ContextMenu("Test It")]
    private void TestIt()
    {
        AddList(testData);
    }

#endregion
}
