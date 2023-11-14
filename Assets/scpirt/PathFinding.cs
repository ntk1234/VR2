using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class PathFinding: MonoBehaviour
{

	NavMeshAgent NM;
	Transform Player;

	void Start()
	{
		NM = GetComponent<NavMeshAgent>();
		Player = GameObject.FindWithTag("Player").transform;
	}

	void Update()
	{
		NM.SetDestination(Player.position);
	}
}
