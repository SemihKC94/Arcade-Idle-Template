/*//////////////////////////////////////////////////////////////////////////////////////////
//      █─▄▄▄▄█▄─█─▄█─▄▄▄─█                                                               //
//      █▄▄▄▄─██─▄▀██─███▀█             Scripts created by Semih Kubilay Çetin            //
//      ▀▄▄▄▄▄▀▄▄▀▄▄▀▄▄▄▄▄▀                                                               //
//////////////////////////////////////////////////////////////////////////////////////////*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolerTest : MonoBehaviour
{
    SKC_PoolSystem myPool;

    private void Start()
    {
        myPool = SKC_PoolSystem.Instance;
    }

    private void FixedUpdate()
    {
        if(Input.GetKey(KeyCode.Space))
        {
            myPool.SpawnFromPool("Pota", transform.position, transform.rotation);
        }
    }
}

/* Tip    #if UNITY_EDITOR
          Debug.Log("Unity Editor");
          #endif                          Tip End */