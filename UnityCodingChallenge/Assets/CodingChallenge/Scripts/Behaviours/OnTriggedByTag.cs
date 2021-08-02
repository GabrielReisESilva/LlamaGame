using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class OnTriggedByTag : MonoBehaviour
{
	public string triggerByTag;
	public UnityEvent events;
	private void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag(triggerByTag))
		{
			events?.Invoke();
		}
	}
}
