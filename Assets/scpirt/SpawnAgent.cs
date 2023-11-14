using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SpawnAgent: MonoBehaviour
{
    public GameObject agentPrefab;

    void Start()
    {
        Vector3 spawnPosition = FindNearestNavMeshPosition(transform.position);
        Instantiate(agentPrefab, spawnPosition, Quaternion.identity);
    }

    private Vector3 FindNearestNavMeshPosition(Vector3 position)
    {
        NavMeshHit hit;
        if (NavMesh.SamplePosition(position, out hit, 5f, NavMesh.AllAreas))
        {
            return hit.position;
        }
        else
        {
            Debug.LogError("�L�k��� NavMesh �W�����Ħ�m�C");
            return position;
        }
    }
}