using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RublishLife : MonoBehaviour
{

    public float maxHealth = 20f;
    public float currentHealth;
    public bool isClear = false;
    public Scoreshow sc;
    public L1Manger L1;


    
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage; // 減少當前生命值

        if (currentHealth <= 0f)
        {

            Die(); // 如果當前生命值小於等於 0，則執行死亡動作
        }
    }


    private void OnCollisionEnter(Collision collision)
    {
        Bullet1 bullet1 = collision.gameObject.GetComponent<Bullet1>();
        if (bullet1 != null)
        {
            if (!bullet1.isShoot)
            {
                TakeDamage(bullet1.damage); // 子弹击中鱼，造成伤害
            }
            bullet1.isShoot = true;
            Destroy(bullet1.gameObject); // 销毁子弹对象
        }
    }

    public void Die()
    {
        // 在這裡實現物件死亡時的動作
        Debug.Log("R clear!");
        // 此處只是銷毀物件，您可以根據遊戲需求進行相應的操作
        if (!isClear)
        { L1.rNUM += 1;
            sc.scoreNunber += 500;        
        }
        isClear = true;
        Destroy(gameObject);

    }
}
