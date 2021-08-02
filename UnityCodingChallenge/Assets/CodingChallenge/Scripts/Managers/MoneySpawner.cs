using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneySpawner : MonoBehaviour
{
    public Pool moneyPool;
    public Vector2Int amountRange = new Vector2Int(5, 10);
    public Vector2 distanceRange = new Vector2(0.5f, 2f);
    public float height = 1.5f;

    void Start()
    {
        if (moneyPool == null)
        {
            Debug.LogError("MONEY SPAWNER: Pool not set");
            return;
        }
        moneyPool.CreatePool();
    }

    public void SpawnMoney(Vector3 center)
    {
        if(moneyPool != null)
        {
            int amount = Random.Range(amountRange.x, amountRange.y);
            for (int i = 0; i < amount; i++)
            {
                Vector3 pos = center + new Vector3(Random.Range(distanceRange.x, distanceRange.y), height, Random.Range(distanceRange.x, distanceRange.y));
                PoolableObject obj = moneyPool.GetPooledObject();
                obj.transform.position = pos;
                obj.gameObject.SetActive(true);
            }
        }
    }
}
