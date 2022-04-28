/*//////////////////////////////////////////////////////////////////////////////////////////
//      █─▄▄▄▄█▄─█─▄█─▄▄▄─█                                                               //
//      █▄▄▄▄─██─▄▀██─███▀█             Scripts created by Semih Kubilay Çetin            //
//      ▀▄▄▄▄▄▀▄▄▀▄▄▀▄▄▄▄▄▀                                                               //
//////////////////////////////////////////////////////////////////////////////////////////*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public ItemObject item;
    public float force;
    public Collider col;

    Rigidbody rb;
    bool go = false;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        col.enabled = false;
    }

    private void Update()
    {
        if(go)
        {
            if (col.enabled == false) col.enabled = true;

            GameObject player = GameObject.FindGameObjectWithTag("Player");
            if (rb.useGravity == true) rb.useGravity = false;
            transform.LookAt(player.transform);
            rb.velocity = transform.forward * force ;
        }
    }
    public void GoToPlayer()
    {
        go = true;   
    }
}

/* Tip    #if UNITY_EDITOR
          Debug.Log("Unity Editor");
          #endif                          Tip End */