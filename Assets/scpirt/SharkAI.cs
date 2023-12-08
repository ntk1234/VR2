using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SharkAI : MonoBehaviour
{
    public float searchRadius = 10f; // 搜尋半徑
    public float searchRadius2 = 5f;
    public LayerMask targetLayer; // 獵物的圖層
    private GameObject target; // 追蹤的目標
    private NavMeshAgent agent; // NavMesh 代理人
    private bool isTracking = false; // 是否正在追蹤玩家
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

                // 如果鯊魚與目標距離在攻擊範圍內，執行攻擊行為
                if (Vector3.Distance(transform.position, target.transform.position) <= agent.stoppingDistance)
                {
                    AttackTarget();
                   
                }
            }
            else
            {
                // 如果目標不存在，停止追蹤
                StopTracking();
              
            }
        }
        if (isTracking2)
        {
            if (target != null)
            {
                

                // 如果鯊魚與目標距離在攻擊範圍內，執行攻擊行為
                if (Vector3.Distance(transform.position, target.transform.position) <= agent.stoppingDistance)
                {
                    playSharkSound();

                }
            }
            else
            {
                // 如果目標不存在，停止追蹤
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
        // 在這裡執行停止追蹤時的行為，例如停止動畫播放等

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
        
        // 在這裡執行攻擊行為，例如播放攻擊動畫、造成傷害等
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