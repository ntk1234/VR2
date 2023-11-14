using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleController: MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // 允许被标记为"Player"的物体通过触发器
            // 执行相应操作或允许通过
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("SmallF"))
        {
            // 阻碍物碰撞处理逻辑
            // 阻止"pane"物体通过阻碍物
        }
    }
}
