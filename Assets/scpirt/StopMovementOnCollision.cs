using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.ThirdPerson;

public class StopMovementOnCollision: MonoBehaviour
{
    private ThirdPersonCharacter m_Character;

    private void Start()
    {
        // 获取角色的ThirdPersonCharacter组件
        m_Character = GetComponent<ThirdPersonCharacter>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        // 检查是否与物体碰撞
        if (collision.gameObject.CompareTag("Map"))
        {
            // 停止角色的移动
            m_Character.Move(Vector3.zero, false, false);
        }
    }
}