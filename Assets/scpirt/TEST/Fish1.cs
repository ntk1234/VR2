using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fish1: MonoBehaviour
{
    public int maxHP = 100;                 // 最大生命值
    public int currentHP;                   // 当前生命值

    public event Action OnSharkKill;       // 捕获鱼的事件

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
        Bullet1 bullet1 = collision.gameObject.GetComponent<Bullet1>();
        if (bullet1 != null)
        {
            TakeDamage(bullet1.damage); // 子弹击中鱼，造成伤害
            Destroy(bullet1.gameObject); // 销毁子弹对象
        }
    }

    private void Die()
    {
        // 死亡的逻辑处理，例如播放死亡动画、销毁鱼对象等
        Destroy(gameObject);

        if (OnSharkKill != null)
        {
            OnSharkKill.Invoke();  // 触发捕获鱼的事件
        }
    }
}