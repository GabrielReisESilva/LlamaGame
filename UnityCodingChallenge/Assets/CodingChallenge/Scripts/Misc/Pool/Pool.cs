using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Pool: MonoBehaviour
{
	public PoolableObject prefab;
	private List<PoolableObject> list;
	public List<PoolableObject> List { get => list; }

	public void CreatePool(int amount = 10)
	{
		if(prefab == null)
        {
			Debug.LogError("POOL: Prefab not set");
			return;
        }

		list = new List<PoolableObject>();
		for (int i = 0; i < amount; i++)
		{
			list.Add(CreateNewObject());
		}
	}

	protected virtual PoolableObject CreateNewObject()
	{
		PoolableObject obj = Instantiate(prefab,transform);
		obj.gameObject.SetActive(false);
		return obj;
	}

	public PoolableObject GetPooledObject()
	{
		for (int i = 0; i < list.Count; i++)
		{
			if (!list[i].gameObject.activeInHierarchy)
			{
				list[i].onPooled?.Invoke();
				return list[i];
			}
		}

		PoolableObject obj = CreateNewObject();
		list.Add(obj);
		obj.onPooled?.Invoke();
		return obj;
	}
}