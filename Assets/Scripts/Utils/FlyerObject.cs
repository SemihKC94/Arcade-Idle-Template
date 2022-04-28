using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyerObject : MonoBehaviour
{
    [Header("Configuration")]
    [SerializeField] private float minModifier = 5f;
    [SerializeField] private float maxModifier = 10f;
    [SerializeField] private float toFlyTime = 1f;

    // Privates
    // Object to fly
    private Transform toTarget;

    // Ref velocity
    private Vector3 refVelocity = Vector3.one;

    // Bool to start fly
    private bool isFollow = false;
    private bool selfDestroy = false;
    private PickupsSO mydata;

    [ContextMenu("Test Fly Object")]
    private void TestFunc()
    {
        StartCoroutine(StartToFly( GameObject.FindGameObjectWithTag("Player").transform));
    }

    private void LateUpdate()
    {
        if (isFollow)
        {
            transform.position = Vector3.SmoothDamp(transform.position, toTarget.position,
                ref refVelocity,
                Random.Range(minModifier, maxModifier) * Time.deltaTime);

            if(selfDestroy) 
            {
                if(Vector3.Distance(transform.position,toTarget.position) < 0.01f)
                {
                    if(mydata != null) CharacterManager.Instance.TakeItem(mydata);
                    Destroy(this.gameObject);
                }
                    
            }
        }
    }

    public void FlyToTarget(Transform target, bool selfDestroyTemp, float tempFlyTime,PickupsSO data)
    {
        toFlyTime = tempFlyTime;
        mydata = data;
        StartCoroutine(StartToFly(target));
        selfDestroy = selfDestroyTemp;
    }

    private IEnumerator StartToFly(Transform target)
    {
        toTarget = target;
        yield return new WaitForSeconds(toFlyTime);
        isFollow = true;
    }
}
