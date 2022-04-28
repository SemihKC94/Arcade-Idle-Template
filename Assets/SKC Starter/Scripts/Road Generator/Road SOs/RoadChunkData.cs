/*//////////////////////////////////////////////////////////////////////////////////////////
//      █─▄▄▄▄█▄─█─▄█─▄▄▄─█                                                               //
//      █▄▄▄▄─██─▄▀██─███▀█             Scripts created by Semih Kubilay Çetin            //
//      ▀▄▄▄▄▄▀▄▄▀▄▄▀▄▄▄▄▄▀                                                               //
//////////////////////////////////////////////////////////////////////////////////////////*/
using UnityEngine;

[CreateAssetMenu(fileName = "New Road Data", menuName = "SKC_Data/Road Generator/Road Data")]
public class RoadChunkData : ScriptableObject
{
    [Header("Configuration")]
    public Vector2 roadChunkSize = new Vector2(10f, 10f);
    public enum Direction
    {
        North,
        East,
        West,
        South
    }
    public GameObject[] roadChunks;
    public Direction entryRoadDir;
    public Direction exitRoadDir;
}

/* Tip    #if UNITY_EDITOR
          Debug.Log("Unity Editor");
          #endif                          Tip End */