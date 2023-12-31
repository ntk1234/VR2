﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class CheckChests : MonoBehaviour
{
    public GameObject chestA;
    public GameObject chestB;
    public GameObject chestC;
    public GameObject chestMap;
    public GameObject chestMap1;
    public GameObject chestMap2;
    public GameObject boxA;
    public GameObject boxB;
    public GameObject boxC;
    public UnityEvent onAllChestsOpened;
    public boatEvent be;

    public PauseMenu1 PM;

    public MouseLock2 ML2;



    private bool isUpdateInputEnabledA = true;
    private bool isUpdateInputEnabledB = true;
    private bool isUpdateInputEnabledC = true;

    // 寶箱打開時調用此方法
    public void Update()
    {
        if (chestA.activeSelf)
        {
            if (isUpdateInputEnabledA)
            {

                chestMap.SetActive(true);
                ML2.UnlockMouse();
                PM.PauseGame();
            }
           ; }
        if (chestB.activeSelf)
        {
            if (isUpdateInputEnabledB)
            {

                chestMap1.SetActive(true);
                ML2.UnlockMouse();
                PM.PauseGame();
            }
            ; }
        if (chestC.activeSelf)
        {
            if (isUpdateInputEnabledC)
            {

                chestMap2.SetActive(true);
                ML2.UnlockMouse();
                PM.PauseGame();
            }
            ;
       
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


    }

