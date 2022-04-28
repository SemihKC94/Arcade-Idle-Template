/*//////////////////////////////////////////////////////////////////////////////////////////
//      █─▄▄▄▄█▄─█─▄█─▄▄▄─█                                                               //
//      █▄▄▄▄─██─▄▀██─███▀█             Scripts created by Semih Kubilay Çetin            //
//      ▀▄▄▄▄▄▀▄▄▀▄▄▀▄▄▄▄▄▀                                                               //
//////////////////////////////////////////////////////////////////////////////////////////*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SKC_PoolSystem : MonoBehaviour
{
    [System.Serializable]
    public struct Pool //In this section, we use created data
    {
        public SKC_PoolObjectData myObject;
    }
    #region SingletonPatternForOurPoolingSystem
    public static SKC_PoolSystem Instance { get; private set; }
    private void Awake()
    {
        Instance = this;
    }
    #endregion //SingletonPattern

    public List<Pool> pools; //List pool class in inspector
    public Dictionary<string, Queue<GameObject>> poolDictionary; // new dictionary for our pool

    public bool inCanvas;

    private void Start()
    {
        poolDictionary = new Dictionary<string, Queue<GameObject>>();//Define our pool

        foreach (Pool pool in pools) //Fill our pool
        {
            Queue<GameObject> objectPool = new Queue<GameObject>();

            GameObject tempObj = new GameObject();
            tempObj.transform.SetParent(this.gameObject.transform);
            if (inCanvas) 
                if(!tempObj.AddComponent<RectTransform>()) tempObj.AddComponent<RectTransform>(); // if UI object we want to spawn
            if(inCanvas) 
            {   
                tempObj.GetComponent<RectTransform>().anchoredPosition = Vector3.zero;
                tempObj.GetComponent<RectTransform>().anchorMin = Vector2.one;
                tempObj.GetComponent<RectTransform>().anchorMax = Vector2.one;
                tempObj.GetComponent<RectTransform>().pivot = Vector2.one;
                tempObj.GetComponent<RectTransform>().sizeDelta = new Vector2(1080,1920);
            }
            tempObj.name = pool.myObject.tag + "Temp";
            for (int i = 0; i < pool.myObject.size; i++)
            {
                GameObject obj = Instantiate(pool.myObject.prefab);
                obj.transform.SetParent(tempObj.transform);
                obj.SetActive(false);
                objectPool.Enqueue(obj);
            }

            poolDictionary.Add(pool.myObject.tag, objectPool);//Add obj in our pool
        }
    }

    public GameObject SpawnFromPool(string tag, Vector3 position, Quaternion rotation)
    {
        if (!poolDictionary.ContainsKey(tag))
        {
            #region DebugLogObjWithTagNotInPool
#if UNITY_EDITOR
            Debug.Log("Pool with tag: " + tag + " doesn't exist ");
#endif
            #endregion
            return null;
        }

        GameObject objectToSpawn = poolDictionary[tag].Dequeue();

        objectToSpawn.SetActive(true);
        objectToSpawn.transform.position = position;
        objectToSpawn.transform.rotation = rotation;

        SKC_IPooledObj pooledObj = objectToSpawn.GetComponent<SKC_IPooledObj>();

        if (pooledObj != null) pooledObj.OnObjectSpawn();

        poolDictionary[tag].Enqueue(objectToSpawn);

        return objectToSpawn;
    }
}

/* Tip    #if UNITY_EDITOR
          Debug.Log("Unity Editor");
          #endif                          Tip End */