using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIControl : MonoBehaviour
{
    private GameObject[] destinations; // 追蹤目標的位置
    private NavMeshAgent agent; // NavMesh 代理人

    void Start()
    {
        destinations = GameObject.FindGameObjectsWithTag("Destination");
        agent = GetComponent<NavMeshAgent>();
        SetRandomDestination();
    }

    void SetRandomDestination()
    {
        if (destinations.Length > 0)
        {
            int randomIndex = Random.Range(0, destinations.Length);
            GameObject randomDestination = destinations[randomIndex];
            agent.SetDestination(randomDestination.transform.position);
        }
    }
}