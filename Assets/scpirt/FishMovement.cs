using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishMovement : MonoBehaviour
{
    public float swimSpeed = 2f;         // 游泳速度
    public float rotationSpeed = 5f;     // 旋转速度
    public float swimRange = 5f;         // 游动范围
    public float maxTurnAngle = 45f;     // 最大转向角度
    public float minPauseTime = 1f;      // 最小停顿时间
    public float maxPauseTime = 3f;      // 最大停顿时间

    private Vector3 targetPosition;      // 目标位置
    private bool isPausing;              // 是否正在停顿
    private float pauseTimer;            // 停顿计时器

    private void Start()
    {
        // 在开始时随机设置初始目标位置和停顿计时器
        targetPosition = GetRandomPosition();
        pauseTimer = Random.Range(minPauseTime, maxPauseTime);
    }

    private void Update()
    {
        if (isPausing)
        {
            // 如果正在停顿，计时器减少
            pauseTimer -= Time.deltaTime;
            if (pauseTimer <= 0f)
            {
                // 停顿结束后重新设置目标位置和停顿计时器
                targetPosition = GetRandomPosition();
                pauseTimer = Random.Range(minPauseTime, maxPauseTime);
                isPausing = false;
            }
        }
        else
        {
            // 计算鱼的移动方向
            Vector3 swimDirection = targetPosition - transform.position;

            // 如果到达目标位置，则开始停顿
            if (swimDirection.magnitude <= 0.1f)
            {
                isPausing = true;
                return;
            }

            // 计算鱼的旋转方向
            Quaternion targetRotation = Quaternion.LookRotation(swimDirection);

            // 计算旋转角度
            float turnAngle = Quaternion.Angle(transform.rotation, targetRotation);

            // 如果旋转角度超过最大转向角度，则将鱼的旋转角度限制在最大转向角度内
            if (turnAngle > maxTurnAngle)
            {
                targetRotation = Quaternion.RotateTowards(transform.rotation, targetRotation, maxTurnAngle);
            }

            // 平滑旋转鱼的方向
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);

            // 鱼向前移动
            transform.Translate(Vector3.forward * swimSpeed * Time.deltaTime);
        }
    }

    private Vector3 GetRandomPosition()
    {
        // 随机生成一个新的目标位置
        Vector2 randomCircle = Random.insideUnitCircle * swimRange;
        Vector3 randomPosition = new Vector3(randomCircle.x, 0f, randomCircle.y);
        return transform.position + randomPosition;
    }
}