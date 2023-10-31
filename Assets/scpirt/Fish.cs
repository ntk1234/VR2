using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fish : MonoBehaviour
{
    public int maxHP = 100;                 // 最大生命值
    public int currentHP;                   // 当前生命值

    private void Start()
    {
        currentHP = maxHP;                  // 初始化当前生命值为最大生命值
    }

    public void TakeDamage(int damage)
    {
        currentHP -= damage;                // 减去伤害值

        if (currentHP <= 0)
        {
            Die();                         // 生命值小于等于0时执行死亡操作
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        Bullet bullet = collision.gameObject.GetComponent<Bullet>();
        if (bullet != null)
        {
            TakeDamage(bullet.damage); // 子弹击中鱼，造成伤害
            Destroy(bullet.gameObject); // 销毁子弹对象
        }
    }

    private void Die()
    {
        // 死亡的逻辑处理，例如播放死亡动画、销毁鱼对象等
        Destroy(gameObject);
    }
}