using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SmallFishAI: MonoBehaviour
{
    public float searchRadius = 10f; // �j�M�b�|
    public LayerMask targetLayer; // �y�����ϼh
    private GameObject target; // �l�ܪ��ؼ�
    private NavMeshAgent agent; // NavMesh �N�z�H
    private bool isTracking = false; // �O�_���b�l�ܪ��a

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        SearchTarget();
    }

    void Update()
    {
        if (isTracking)
        {
            if (target != null)
            {
                agent.SetDestination(target.transform.position);

                // �p�G�T���P�ؼжZ���b�����d�򤺡A��������欰
                if (Vector3.Distance(transform.position, target.transform.position) <= agent.stoppingDistance)
                {
                    AttackTarget();
                }
                else
                {
                    // �p�G�ؼЦs�b�A�T���������a
                    MoveAwayFromPlayer();
                }
            }
            else
            {
                // �p�G�ؼФ��s�b�A����l��
                StopTracking();
            }
        }
    }

    void SearchTarget()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, searchRadius, targetLayer);
        if (colliders.Length > 0)
        {
            target = colliders[Random.Range(0, colliders.Length)].gameObject;
            isTracking = true;
            Debug.Log("Found target: " + target.name);
        }
    }

    void StopTracking()
    {
        isTracking = false;
        // �b�o�̰��氱��l�ܮɪ��欰�A�Ҧp����ʵe����
        Debug.Log("Lost target");
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StopTracking();
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            SearchTarget();
        }
    }

    void AttackTarget()
    {
        // �b�o�̰�������欰�A�Ҧp��������ʵe�B�y���ˮ`��
        Debug.Log("Attacking target: " + target.name);
    }

    void MoveAwayFromPlayer()
    {
        Vector3 awayFromPlayer = transform.position - target.transform.position;
        Vector3 destination = transform.position + awayFromPlayer.normalized * searchRadius;
        agent.SetDestination(destination);
        Debug.Log("Moving away from player");
    }

}