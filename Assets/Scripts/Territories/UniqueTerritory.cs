using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class UniqueTerritory : MonoBehaviour
{
    // Get Childs Component
    public List<Transform> territoryGrounds => transform.GetChild(0).GetChildren();

    public List<Renderer> territoryGroundsRenderer => territoryGrounds.GetRendererToTransformLists();

    public List<NavMeshSurface> territoryGroundsNavMeshSurfaces => territoryGrounds.GetNavMeshSurfacesToTransformLists();

#region Custom Accessable Methods
    public void CheckOwnStatus(List<int> savedPlaneList, List<PlaneInfo> savedInPlaneConfig)
    {
        for (int i = 0; i < savedPlaneList.Count; i++)
        {
            territoryGrounds[i].GetComponent<Plane1x1>().Init(i,savedPlaneList[i],savedInPlaneConfig[i]);
        }
    }

    public void TerrirotyNavMeshes()
    {
        for (int i = 0; i < territoryGrounds.Count; i++)
        {
            if(territoryGrounds[i].gameObject.activeSelf == true)
            {
                territoryGrounds[i].GetComponent<Plane1x1>().BuildNavMeshes();
            }
        }
    }
    public bool ifZoneCleared()
    {
        int a = 0;
        for (int i = 0; i < territoryGrounds.Count; i++)
        {
            if(territoryGrounds[i].gameObject.activeSelf == false)
            {
                a++;
            }
        }
        if(a > 0) return false;
        else return true;
    }

    public void ChangeMaterial(Material mat)
    {
        foreach (Renderer item in territoryGroundsRenderer)
        {
            item.material = mat;
        }
    }
#endregion
}
