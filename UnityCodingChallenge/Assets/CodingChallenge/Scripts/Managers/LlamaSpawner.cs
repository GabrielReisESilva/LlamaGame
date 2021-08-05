using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class LlamaSpawner : MonoBehaviour
{
    private const int MAX_WILD_LLAMAS = 5;

    public Pool llamaPool;
    public LayerMask groundLayer;
    public Vector2 spawnerDelayRange = new Vector2(3f, 7f);

    [Header("Spawn Area")]
    public Vector2 minSpawnBoundries = new Vector2(-10f, -10f);
    public Vector2 maxSpawnBoundries = new Vector2(10f, 10f);

    private int llamaCount;
    // Start is called before the first frame update
    void Start()
    {
        if (llamaPool != null)
        {
            llamaPool.CreatePool();

            for (int i = 0; i < MAX_WILD_LLAMAS; i++)
            {
                TryToSpawnWildLlama();
            }
        }
        else
        {
            Debug.LogError("LLAMA SPAWNER: Pool not found");
        }
    }

    // Update is called once per frame

    public void OnLlamaCaptured()
    {
        llamaCount--;
        TryToSpawnWildLlama();
    }
    private void TryToSpawnWildLlama()
    {
        //Spawn a new llama if it doesn't exceed the limit of wild llamas
        if (llamaCount < MAX_WILD_LLAMAS)
        {
            StartCoroutine(SpawnNewLlama());
            llamaCount++;
        }
    }
    private Vector3 FindPositionInNavMesh(Vector3 origin, Vector2 minBoundries, Vector2 maxBoundries, LayerMask layerMask)
    {
        //Try to find a spot for the new llama inside a walkable navmesh
        Vector3 randomPos = origin + new Vector3(Random.Range(minBoundries.x, maxBoundries.x), 0f, Random.Range(minBoundries.y, maxBoundries.y));

        NavMeshHit navMeshHit;
        int watchdog = 20;
        while (watchdog > 0)
        {
            watchdog--;
            if(NavMesh.SamplePosition(randomPos, out navMeshHit, 10f, 1 << layerMask))
            {
                return navMeshHit.position;
            }
        }

        Debug.LogWarning("LLAMA SPAWNER: Couldn't find a place for the llama :(");
        return origin;
    }

    private IEnumerator SpawnNewLlama()
    {
        yield return new WaitForSeconds(Random.Range(spawnerDelayRange.x, spawnerDelayRange.y));

        PoolableObject llama = llamaPool.GetPooledObject();
        Vector3 pos = FindPositionInNavMesh(transform.position, minSpawnBoundries, maxSpawnBoundries, groundLayer);
        if (pos.magnitude != Mathf.Infinity)
        {
            llama.transform.position = pos;
            llama.gameObject.SetActive(true);
        }
    }
}
