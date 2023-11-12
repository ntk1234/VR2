using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SharkAttack : MonoBehaviour
{
    public float speed = 5f; // 鯊魚移動速度
    public float attackRange = 2f; // 攻擊範圍
    public float attackDamage = 10f; // 攻擊傷害
    public float patrolDistance = 2f; // 巡邏距離
    public float patrolSpeed = 2f; // 巡邏速度
    public float resetDistance = 10f; // 重置距離

    private Transform target; // 攻擊目標
    private bool isAttacking = false; // 是否正在攻擊
    private bool isPatrolling = false; // 是否正在巡邏
    private Vector3 patrolStartPosition; // 巡邏起始位置
    private Vector3 initialPosition; // 初始位置
    private Quaternion initialRotation; // 初始旋轉

    private void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        patrolStartPosition = transform.position;

        // 記錄初始位置和旋轉
        
    }

    private void Update()
    {
        if (target == null)
            return;

        if (isAttacking)
            return;

        Vector3 direction = target.position - transform.position;
        direction.y = 0f;
        transform.rotation = Quaternion.LookRotation(direction, Vector3.up);

        if (direction.magnitude <= attackRange)
        {
            Attack();
        }
        else if (!isPatrolling)
        {
            transform.position += transform.forward * speed * Time.deltaTime;
        }
        else
        {
            float distanceToStart = Vector3.Distance(transform.position, patrolStartPosition);
            if (distanceToStart < patrolDistance)
            {
                transform.position += transform.forward * patrolSpeed * Time.deltaTime;
            }
            else
            {
                transform.rotation = initialRotation; // 重置旋轉
                isPatrolling = false;
            }
        }

        // 檢查玩家距離是否大於重置距離
        if (Vector3.Distance(transform.position, target.position) > resetDistance)
        {
            ResetShark();
        }
    }

    private void Attack()
    {
        isAttacking = true;
        Debug.Log("Shark attacks!");

        Health targetHealth = target.GetComponent<Health>();
        if (targetHealth != null)
        {
            targetHealth.TakeDamage(attackDamage);
        }

        isPatrolling = true;

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isAttacking = true;
        }
    }

    private void ResetShark()
    {
        // 重置鯊魚的狀態
       

        // 停止攻擊和巡邏
        isAttacking = false;
        isPatrolling = false;
       
    }
}