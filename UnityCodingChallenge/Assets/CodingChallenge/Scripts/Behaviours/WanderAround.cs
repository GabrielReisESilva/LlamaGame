using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WanderAround : MonoBehaviour
{
    public Vector2 wanderingRange = new Vector2(1f, 2f);
    public Vector2 decisionTimeRange = new Vector2(5f, 10f);
    public LayerMask groundLayer;

    private float wanderingRadius = 0;
    private float decisionTime = 0;
    private float timer = 0;
    private Vector3 wanderingPosition = Vector3.zero;

    private NavMeshAgent agent;

    void Start()
    {
        agent = GetComponentInChildren<NavMeshAgent>();
        if (agent == null)
        {
            Debug.LogError("WANDER AROUND: Agent not found!");
        }
    }
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > decisionTime)
        {
            wanderingRadius = Random.Range(wanderingRange.x, wanderingRange.y);
            wanderingPosition = FindPositionInNavMesh(transform.position, wanderingRadius, groundLayer);
            if (agent != null)
            {
                agent.SetDestination(wanderingPosition);
            }
            decisionTime = Random.Range(decisionTimeRange.x, decisionTimeRange.y);
            timer = 0;
        }
    }
    public void TeleportTo(Vector3 position)
    {
        if (agent != null)
        {
            agent.Warp(position);
        }
    }
    private static Vector3 FindPositionInNavMesh(Vector3 origin, float radius, LayerMask layerMask)
    {
        Vector3 randomPos = origin + Random.insideUnitSphere * radius;

        NavMeshHit navMeshHit;
        NavMesh.SamplePosition(randomPos, out navMeshHit, radius, 1 << layerMask);

        return navMeshHit.position;
    }
}
