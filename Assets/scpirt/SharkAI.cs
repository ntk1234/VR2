using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SharkAI : MonoBehaviour
{
    public float searchRadius = 10f; // �j�M�b�|
    public float searchRadius2 = 5f;
    public LayerMask targetLayer; // �y�����ϼh
    private GameObject target; // �l�ܪ��ؼ�
    private NavMeshAgent agent; // NavMesh �N�z�H
    private bool isTracking = false; // �O�_���b�l�ܪ��a
    private bool isTracking2 = false;
    private AudioSource audioData;
    public AudioClip sharkSound;

    void Start()
    {
        
        agent = GetComponent<NavMeshAgent>();
        SearchTarget();
        SearchTarget2();
       
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
            }
            else
            {
                // �p�G�ؼФ��s�b�A����l��
                StopTracking();
              
            }
        }
        if (isTracking2)
        {
            if (target != null)
            {
                

                // �p�G�T���P�ؼжZ���b�����d�򤺡A��������欰
                if (Vector3.Distance(transform.position, target.transform.position) <= agent.stoppingDistance)
                {
                    playSharkSound();

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
        }
    }
    void SearchTarget2()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, searchRadius2, targetLayer);
        if (colliders.Length > 0)
        {
            target = colliders[Random.Range(0, colliders.Length)].gameObject;
            isTracking2 = true;
        }
    }

    void StopTracking()
    {
        
        isTracking = false;
        isTracking2 = false;
        // �b�o�̰��氱��l�ܮɪ��欰�A�Ҧp����ʵe����

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

   void playSharkSound()
    {
        GameObject audioObject = new GameObject("SharkSound");
        audioData = audioObject.AddComponent<AudioSource>();
        audioData.clip = sharkSound;
        audioData.volume = 0.8f;
        audioData.Play(); 
    }
}