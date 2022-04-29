/*//////////////////////////////////////////////////////////////////////////////////////////
//      █─▄▄▄▄█▄─█─▄█─▄▄▄─█                                                               //
//      █▄▄▄▄─██─▄▀██─███▀█             Scripts created by Semih Kubilay Çetin            //
//      ▀▄▄▄▄▄▀▄▄▀▄▄▀▄▄▄▄▄▀                                                               //
//////////////////////////////////////////////////////////////////////////////////////////*/
using System.Collections.Generic;
using UnityEngine;

public class TerritoryManager : MonoBehaviour
{
    [SKC_ReadOnly][SerializeField] private string TerritoriesAlert = "Just only to able to territories see in inspector";
    [SerializeField] private bool navmeshAreas;
    
    [SKC_ReadOnly][SerializeField] private string NavmeshAreas = "Just only Navigation Agents";
    [SerializeField] private bool showMaterials;
    [SKC_ConditionalHide("showMaterials", true)] [SerializeField] private Material ourTerritoryMat = null;
    [SKC_ConditionalHide("showMaterials", true)] [SerializeField] private Material enemyTerritoryMat = null;

    public List<UniqueTerritory> uniqueTerritories => transform.GetUniqueTerritoriesFromTransformList();
    
    public static TerritoryManager Instance {get; private set;}

#region Unity Methods
    private void Awake()
    {  
        Instance = this;
    }

    private void Start()
    {
        Init();
    }

#endregion

#region Custom Private Methods
    private void Init()
    {
        Invoke("CheckZonesStatus",1f);
    }
    private void ChangeMaterial()
    {
        foreach (UniqueTerritory item in uniqueTerritories)
        {
            if(item.gameObject.activeSelf == true)
            {
                item.ChangeMaterial(ourTerritoryMat);
            }
        }
    }

    private void CheckZonesStatus()
    {
        for (int i = 0; i < GameManager.SaveData.TerritoriesOwnStatus.Zone.Count; i++)
        {          
            uniqueTerritories[i].CheckOwnStatus(GameManager.SaveData.TerritoriesOwnStatus.Zone[i].Plane,GameManager.SaveData.TerritoriesOwnStatus.Zone[i].PlaneInfoInc);
        }

        //BuildNavMeshAreas();
    }

    // Build All Navmesh
    // private void BuildNavMeshAreas()
    // {
    //     if(navmeshAreas)
    //     {
    //         foreach (UniqueTerritory item in uniqueTerritories)
    //         {
    //             item.BuildNavMeshes();
    //         }
    //     }
    // }

#endregion

#region Custom Accessable Methods

    public void CheckOurZone()
    {
        foreach (UniqueTerritory item in uniqueTerritories)
        {
            if(item.ifZoneCleared())
            {
                item.ChangeMaterial(ourTerritoryMat);
            }
        }
    }
#endregion
}
/* Tip    #if UNITY_EDITOR
          Debug.Log("Unity Editor");
          #endif                          Tip End */