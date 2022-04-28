/*//////////////////////////////////////////////////////////////////////////////////////////
//      █─▄▄▄▄█▄─█─▄█─▄▄▄─█                                                               //
//      █▄▄▄▄─██─▄▀██─███▀█             Scripts created by Semih Kubilay Çetin            //
//      ▀▄▄▄▄▄▀▄▄▀▄▄▀▄▄▄▄▄▀                                                               //
//////////////////////////////////////////////////////////////////////////////////////////*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadGenerator : MonoBehaviour
{
    [Header("Configuration")]
    [SerializeField] private RoadChunkData[] roadsData = null;
    [SerializeField] private RoadChunkData firstRoadChunk = null;
    [Space] [SerializeField] private Vector3 spawnOrigin = new Vector3(0f, 0f, 0f);
    [Space] [SerializeField] private int roadChunkSpawnAmount = 10;

    //Private vars
    private RoadChunkData preRoadChunk;
    private Vector3 spawnPosition;

    #region Unity Methods
    private void Start()
    {
        //Generate road when game start
        preRoadChunk = firstRoadChunk;

        for (int i = 0; i < roadChunkSpawnAmount; i++)
        {
            SelectRoadToSpawn();
        }
    }

    private void OnEnable()
    {
        ExitAction.WhenExitChunk += SelectRoadToSpawn;
    }

    private void OnDisable()
    {
        ExitAction.WhenExitChunk -= SelectRoadToSpawn;
    }

    private void Update()
    {
        //Test Generator
        if(Input.GetKeyDown(KeyCode.R))
        {
            SelectRoadToSpawn();
        }
    }
    #endregion

    #region Calculate and Spawn Road
    RoadChunkData SelectNextRoad()
    {
        List<RoadChunkData> nextRoadList = new List<RoadChunkData>();
        RoadChunkData nextRoadChunk = null;

        RoadChunkData.Direction nextDirection = RoadChunkData.Direction.North;

        switch(preRoadChunk.exitRoadDir)
        {
            case RoadChunkData.Direction.North:
                nextDirection = RoadChunkData.Direction.South;
                spawnPosition = spawnPosition + new Vector3(0f, 0f, preRoadChunk.roadChunkSize.y);
                
                break;

            case RoadChunkData.Direction.East:
                nextDirection = RoadChunkData.Direction.West;
                spawnPosition = spawnPosition + new Vector3(preRoadChunk.roadChunkSize.x, 0f, 0f);

                break;

            case RoadChunkData.Direction.West:
                nextDirection = RoadChunkData.Direction.East;
                spawnPosition = spawnPosition + new Vector3(-preRoadChunk.roadChunkSize.x, 0f, 0f);

                break;

            case RoadChunkData.Direction.South:
                nextDirection = RoadChunkData.Direction.North;
                spawnPosition = spawnPosition + new Vector3(0f, 0f, -preRoadChunk.roadChunkSize.y);

                break;
        }

        for (int i = 0; i < roadsData.Length; i++)
        {
            if(roadsData[i].entryRoadDir == nextDirection)
            {
                nextRoadList.Add(roadsData[i]);
            }
        }

        nextRoadChunk = nextRoadList[Random.Range(0, nextRoadList.Count)];

        return nextRoadChunk;
    }

    void SelectRoadToSpawn()
    {
        RoadChunkData roadToSpawn = SelectNextRoad();

        GameObject objFromRoadChunk = roadToSpawn.roadChunks[Random.Range(0, roadToSpawn.roadChunks.Length)];
        preRoadChunk = roadToSpawn;
        Instantiate(objFromRoadChunk, spawnPosition + spawnOrigin, Quaternion.identity,this.transform);
    }

    public void UpdateSpawnOrigin(Vector3 originDelta)
    {
        spawnOrigin = spawnOrigin + originDelta;
    }

    #endregion
}

/* Tip    #if UNITY_EDITOR
          Debug.Log("Unity Editor");
          #endif                          Tip End */