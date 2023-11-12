using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIControl : MonoBehaviour
{
    private GameObject[] destinations; // �l�ܥؼЪ���m
    private NavMeshAgent agent; // NavMesh �N�z�H

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