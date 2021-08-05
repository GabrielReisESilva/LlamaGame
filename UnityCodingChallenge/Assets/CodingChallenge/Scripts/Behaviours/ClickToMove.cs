using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.EventSystems;

//Move gameobject when mouse click on an objet in "groundLayer" layer
public class ClickToMove : MonoBehaviour
{
	public LayerMask groundLayer;
	public Animator playerAnimator;

	private Camera mainCam;
	private NavMeshAgent agent;

	void Start()
	{
		agent = GetComponentInChildren<NavMeshAgent>();
		mainCam = Camera.main;
		if (agent == null)
		{
			Debug.LogError("MOVE TO CLICK: Agent not found!");
		}
		if (mainCam == null)
		{
			Debug.LogError("MOVE TO CLICK: Camera not found!");
		}
	}

	void Update()
	{
		if (Input.GetMouseButtonDown(0))
		{
			if (mainCam != null)
			{
				if (EventSystem.current == null || !EventSystem.current.IsPointerOverGameObject())
				{
					Ray ray = mainCam.ScreenPointToRay(Input.mousePosition);
					RaycastHit hit;
					if (Physics.Raycast(ray, out hit, 100, groundLayer))
					{
						if (agent != null)
						{
							agent.SetDestination(hit.point);
						}
					}
				}
			}
		}
	}
}
