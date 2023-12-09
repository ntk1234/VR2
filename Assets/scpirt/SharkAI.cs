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
   
    
    /*public AudioClip sharkSound;*/

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

                // 如果鯊魚與目標距離在攻擊範圍內，執行攻擊行為
                if (Vector3.Distance(transform.position, target.transform.position) <= agent.stoppingDistance)
                {
                    AttackTarget();
                    /*if (sharkSound != null)
                    {
                        GameObject audioObject = new GameObject("SharkSound");
                        AudioSource audioData = audioObject.AddComponent<AudioSource>();
                        audioData.clip = sharkSound;
                        audioData.volume = 0.8f;
                        audioData.Play();
                        Destroy(audioObject, sharkSound.length);
                    }*/

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
   

    void StopTracking()
    {
        
        isTracking = false;
        
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

   
}