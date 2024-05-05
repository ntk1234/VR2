using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering.PostProcessing;

public class gasHealth: MonoBehaviour
{
    public float maxHealth = 100f; // 物件的最大生命值
    public float currentHealth;
    public float currentHealthB;
    public PauseMenu1 PM1;
    public Health health;
  
    public GameObject gameOver;
    
    public MouseLock2 ML2;
    public MouseLock3 ML3;
    public KeyCode captureKey = KeyCode.V;
    public int gasset = 2;
    public bool isnogass = false;
    public bool isaddgass = false;

    public bool isdie = false;
    public float a =0;

    public PanCol PC;
    // 物件的當前生命值
    public Scoreshow sc;

    public bool isGasLock = false;


    private void Start()
    {
        currentHealth = maxHealth; // 初始化當前生命值為最大生命值
        isdie = false;
        PC = FindObjectOfType<PanCol>();
        sc = FindObjectOfType<Scoreshow>();


    }
    public void Update()

    {
        if (!PC.isOPBK ) {
            if (ML2.isMouseLocked != false||!isGasLock)
            {
           

                    currentHealth -= 0.01f;
                
            }
        if (!isnogass&&Input.GetKeyDown(captureKey))
        {
            isaddgass = true;
         

                gasset -= 1;
            Debug.Log("gass:" + gasset);
        }
        if(isaddgass)
        {

            Addgass();

        }

        if (gasset<=0)
        {
            gasset = 0;
            isnogass = true;
        }

        
        if(currentHealth>=100f)
        {
            currentHealth =100f;
            isaddgass = false;
        }

     
            if (currentHealth <= 0f)
        {

            currentHealth = 0f;
          if (!isdie)
           { 
                    Die();
               }
            // 如果當前生命值小於等於 0，則執行死亡動作
        }

        }
    }
  

    // 承受傷害
    public void Regass(float regass)
    {
        currentHealth += regass; // 減少當前生命值

    }
    public void Addgass()
    {
        if (isaddgass)
        {
            currentHealth += 0.1f;
            a += 0.01f;
            if (a > 20f)
            {
                a = 0;
                isaddgass = false;
            }
        }       
       
    }
 

    // 死亡
    public void Die()
    {
        // 在這裡實現物件死亡時的動作
        Debug.Log("Player died!");
        // 此處只是銷毀物件，您可以根據遊戲需求進行相應的操作
        gameOver.SetActive(true);
        PlayerPrefs.SetInt("LevelPassed", 4);
        sc.SaveScore();
        ML2.UnlockMouse();
        PM1.PauseGame();
        isdie = true;
    }
  
}