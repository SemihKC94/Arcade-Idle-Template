/*//////////////////////////////////////////////////////////////////////////////////////////
//      █─▄▄▄▄█▄─█─▄█─▄▄▄─█                                                               //
//      █▄▄▄▄─██─▄▀██─███▀█             Scripts created by Semih Kubilay Çetin            //
//      ▀▄▄▄▄▄▀▄▄▀▄▄▀▄▄▄▄▄▀                                                               //
//////////////////////////////////////////////////////////////////////////////////////////*/
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
/* Tip    #if UNITY_EDITOR
          Debug.Log("Unity Editor");
          #endif                          Tip End */
