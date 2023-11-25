using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheckGameOver : MonoBehaviour

{
    public Health hp;

    public GameObject gameOver;
    public Text killShark;
    public int fishCount = 0;  // 鱼的计数器
    public int sharkCount = 0;
    public bool isCheckGO = true;
    public PauseMenu1 PM;

    // Start is called before the first frame update
    private void Start()
    {
        Fish[] fishes = FindObjectsOfType<Fish>();
        foreach (Fish fish in fishes)
        {
            fish.OnFishCaught += IncreaseFishCount;
        }
        Fish1[] fishes1 = FindObjectsOfType<Fish1>();
        foreach (Fish1 fish1 in fishes1)
        {
            fish1.OnSharkKill += IncreaseFishCount;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
            if (hp.currentHealth <= 0f)
            {
                Debug.Log("Player died2222!");
            if (isCheckGO)
            {
                Die();
                // 如果當前生命值小於等於 0，則執行死亡動作
                Time.timeScale = 0f;
            }

            }
    }


    private void IncreaseFishCount()
    {
        fishCount++;  // 捕获到鱼，计数器加1
        Debug.Log("Fish caught! Total count: " + fishCount);
        sharkCount++;
        Debug.Log("Fish caught! Total count: " + sharkCount);
    }


    public void TakeDamage(float damage)
    {
         // 減少當前生命值

      
    }

    public void Die()
    {
        // 在這裡實現物件死亡時的動作
        Debug.Log("Player died!");// 此處只是銷毀物件，您可以根據遊戲需求進行相應的操作
        gameOver.SetActive(true);
        killShark.text="Kill shark:" + sharkCount;
    }

        
    public void closCheckGO()
    {
        isCheckGO = false;
    }
}
