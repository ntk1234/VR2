using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public float maxHealth = 100f; // 物件的最大生命值
    public float currentHealth; // 物件的當前生命值

    private void Start()
    {
        currentHealth = maxHealth; // 初始化當前生命值為最大生命值
    }

    // 承受傷害
    public void TakeDamage(float damage)
    {
        currentHealth -= damage; // 減少當前生命值

        if (currentHealth <= 0f)
        {
            Die(); // 如果當前生命值小於等於 0，則執行死亡動作
        }
    }

    // 死亡
    private void Die()
    {
        // 在這裡實現物件死亡時的動作
        Debug.Log("Player died!");// 此處只是銷毀物件，您可以根據遊戲需求進行相應的操作
    }
}