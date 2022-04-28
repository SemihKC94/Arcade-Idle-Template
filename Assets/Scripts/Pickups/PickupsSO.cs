using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="New Pickup Object Data",menuName = "Arcade Idle/Pickup Object Data")]
public class PickupsSO : ScriptableObject
{
    [Header("Tags")]
    [Space(10)]

    public PickupType itemType;
    public PickupTier itemTier;

    [SKC_TagSelector]
    public string targetTag = "";

    [Header("Items")]
    public GameObject itemAir;
    public GameObject itemEarth;
    public GameObject itemFire;
    public GameObject itemWater;

}

