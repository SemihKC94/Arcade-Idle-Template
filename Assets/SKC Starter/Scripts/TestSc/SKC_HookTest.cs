/*//////////////////////////////////////////////////////////////////////////////////////////
//      █─▄▄▄▄█▄─█─▄█─▄▄▄─█                                                               //
//      █▄▄▄▄─██─▄▀██─███▀█             Scripts created by Semih Kubilay Çetin            //
//      ▀▄▄▄▄▄▀▄▄▀▄▄▀▄▄▄▄▄▀                                                               //
//////////////////////////////////////////////////////////////////////////////////////////*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SKC_HookTest : MonoBehaviour
{
	//Test Hook SC

	private bool tethered = false;
	private Rigidbody rb;
	private float tetherLength;
	private Vector3 tetherPoint;

	void Start()
	{
		rb = GetComponent<Rigidbody>();
	}

	void Update()
	{
		if (Input.GetKey(KeyCode.Space))
		{
			if (!tethered)
			{
				BeginGrapple();
			}
			else
			{
				EndGrapple();
			}
		}
	}

	void FixedUpdate()
	{
		if (tethered) ApplyGrapplePhysics();
	}

	void BeginGrapple()
	{
		if (Physics.Raycast(transform.position, transform.forward, out RaycastHit hit, Mathf.Infinity))
		{
			tethered = true;
			tetherPoint = hit.point;
			tetherLength = Vector3.Distance(tetherPoint, transform.position);
		}
	}

	void EndGrapple()
	{
		tethered = false;
	}

	void ApplyGrapplePhysics()
	{
		Vector3 directionToGrapple = Vector3.Normalize(tetherPoint - transform.position);
		float currentDistanceToGrapple = Vector3.Distance(tetherPoint, transform.position);

		float speedTowardsGrapplePoint = Mathf.Round(Vector3.Dot(rb.velocity, directionToGrapple) * 100) / 100;

		if (speedTowardsGrapplePoint < 0)
		{
			if (currentDistanceToGrapple > tetherLength)
			{
				rb.velocity -= speedTowardsGrapplePoint * directionToGrapple;
				rb.position = tetherPoint - directionToGrapple * tetherLength;
			}
		}
	}
}

/* Tip    #if UNITY_EDITOR
          Debug.Log("Unity Editor");
          #endif                          Tip End */