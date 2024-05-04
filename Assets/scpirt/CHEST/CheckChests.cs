using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class CheckChests: MonoBehaviour
{
    public GameObject chestA;
    public GameObject chestB;
    public GameObject chestC;
    public GameObject q;
    public GameObject chestMap;
    public GameObject chestMap1;
    public GameObject chestMap2;
    public GameObject qMap;
    public GameObject boxA;
    public GameObject boxB;
    public GameObject boxC;


    public UnityEvent onAllChestsOpened;
    public boatEvent be;

    public PauseMenu1 PM;

    public MouseLock2 ML2;

    public L2Manger L2M;

    public Scoreshow sc;

    public bool isupdatedscoreA = false;
    public bool isupdatedscoreB = false;
    public bool isupdatedscoreC = false;

    public bool isUpdateInputEnabledA = true;
    public bool isUpdateInputEnabledB = true;
    public bool isUpdateInputEnabledC = true;
    private bool isUpdateInputEnabledQ = true;
    // 寶箱打開時調用此方法

    public void Start()
    {
        sc = FindObjectOfType<Scoreshow>();
    }

    public void Update()
    {
        if (chestA.activeSelf)
        {

            {
                if (isUpdateInputEnabledA)
                {

                    if (!isupdatedscoreA)
                    {
                        L2M.numOpenbox++;
                        sc.scoreNunber += 1000;
                        isupdatedscoreA = true;
                    }
                    chestMap.SetActive(true);
                    ML2.UnlockMouse();
                    PM.PauseGame();
                }
           ;
            }
            
            }
        if (chestB.activeSelf)
        {
      
            {
                if (isUpdateInputEnabledB)
                {
                    if (!isupdatedscoreB)
                    {
                        L2M.numOpenbox++;
                        sc.scoreNunber += 1000;
                        isupdatedscoreB = true;
                    }

                    chestMap1.SetActive(true);
                    ML2.UnlockMouse();
                    PM.PauseGame();
                }
            ;
            }
            }
        if (chestC.activeSelf)
        {

        
            {
                if (isUpdateInputEnabledC)
                {
                    if (!isupdatedscoreC)
                    {
                        L2M.numOpenbox++;
                        sc.scoreNunber += 1000;
                        isupdatedscoreC = true;
                    }

                    chestMap2.SetActive(true);
                    ML2.UnlockMouse();
                    PM.PauseGame();
                }
            ;
            }
        }
        



        // 檢查所有寶箱是否都已打開
        if (chestA.activeSelf && chestB.activeSelf && chestC.activeSelf)
        {
            // 觸發離開事件
            Debug.Log("事件ON");
            /*onAllChestsOpened.Invoke( ) ;*/

            be.isTextEnabled1 = false;
            be.isLeave = true;
         
        }



        if (q.activeSelf)
        {
            if (isUpdateInputEnabledQ)
            {

                qMap.SetActive(true);
                ML2.UnlockMouse();
                PM.PauseGame();
            }
         ;

        }
        /*if(q.activeSelf==false)
        {
            isUpdateInputEnabledQ = false
            ;
        }*/
    }


 


    public void isUpdateInputA()
    {
        isUpdateInputEnabledA = false;

    }
    public void isUpdateInputB()
    {
        isUpdateInputEnabledB = false;
    }
    public void isUpdateInputC()
    {
        isUpdateInputEnabledC = false;
    }

    public void isUpdateInputQ()
    {
        isUpdateInputEnabledQ = false;
    }


    public void desA()
    {

        Destroy(boxA);
    }
    public void desB()
    {

        Destroy(boxB);
    }
    public void desC()
    {

        Destroy(boxC);
    }

    public void closeQ()
    {
        q.SetActive(false);
    }
    

    }

