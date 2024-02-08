using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health: MonoBehaviour
{
    public float maxHealth = 100f; // 物件的最大生命值
    public float currentHealth;
    public PauseMenu1 PM1;
    public Text killShark;
    public Text killShark2;
    public GameObject gameOver;
    public int fishCount = 0;  // 鱼的计数器
    public int sharkCount = 0;
    public MouseLock2 ML2;
  
    // 物件的當前生命值

    private void Start()
    {
        currentHealth = maxHealth; // 初始化當前生命值為最大生命值

        Fish[] fishes = FindObjectsOfType<Fish>();
        foreach (Fish fish in fishes)
        {
            fish.OnFishCaught += IncreaseFishCount;
        }
        Fish1[] fishes1 = FindObjectsOfType<Fish1>();
        foreach (Fish1 fish1 in fishes1)
        {
            fish1.OnSharkKill += IncreaseSharkCount;
        }
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
    private void IncreaseFishCount()
    {
        fishCount++;  // 捕获到鱼，计数器加1
        Debug.Log("Fish caught! Total count: " + fishCount);
        
       
    }
    private void IncreaseSharkCount()
    {
      ;
        sharkCount++;
        Debug.Log("Kill shark! Total count: " + sharkCount);
        killShark2.text = "Kill shark:" + sharkCount;
    }


    // 死亡
    public void Die()
    {
        // 在這裡實現物件死亡時的動作
        Debug.Log("Player died!");
        // 此處只是銷毀物件，您可以根據遊戲需求進行相應的操作
        gameOver.SetActive(true);
        killShark.text = "Kill shark:" + sharkCount;
        ML2.UnlockMouse();
        PM1.PauseGame();
    }

  
}