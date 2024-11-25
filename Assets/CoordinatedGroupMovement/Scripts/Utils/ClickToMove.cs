﻿// ClickToMove.cs
using UnityEngine;

[RequireComponent (typeof(UnityEngine.AI.NavMeshAgent))]
public class ClickToMove : MonoBehaviour
{
	RaycastHit hitInfo = new RaycastHit ();
	UnityEngine.AI.NavMeshAgent agent;

	void Start ()
	{
		agent = GetComponent<UnityEngine.AI.NavMeshAgent> ();
	}

	void Update ()
	{
		if (Input.GetMouseButtonDown (0)) {
			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
			int mask = 1 << LayerMask.NameToLayer ("Ground");
			if (Physics.Raycast (ray.origin, ray.direction, out hitInfo, 999999.0f, mask))
				agent.destination = hitInfo.point;
		}
	}
}
