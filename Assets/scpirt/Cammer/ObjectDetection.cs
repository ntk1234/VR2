﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectDetection : MonoBehaviour
{
    public GameObject[] objectsToDetect; // 要偵測的物體
    public float detectionDelay = 1f; // 偵測間隔時間

    private Camera mainCamera;
    private bool isObjectDetected = false;
    public CameraController1 CC;
   
    public PanCol PC;
    public L1Manger L;

 
    public bool ispressed = false;

    public KeyCode captureKey = KeyCode.C;
    private void Start()
    {
        mainCamera = Camera.main;
        InvokeRepeating("DetectObject", detectionDelay, detectionDelay);
        L = FindObjectOfType<L1Manger>();
        CC = FindObjectOfType< CameraController1>();
        ispressed = false;
    }

    private void DetectObject()
    {
        foreach (GameObject obj in objectsToDetect)
        {
            Vector3 viewPos = mainCamera.WorldToViewportPoint(obj.transform.position);

            //if (viewPos.x > 0 && viewPos.x < 1 && viewPos.y > 0 && viewPos.y < 1 && viewPos.z > 0)

                if (viewPos.x > 0 && viewPos.x <  1&& viewPos.y > 0 && viewPos.y < 1&& viewPos.z > 0)
                {
                    if (!isObjectDetected && CC.isTakPH)
                    {
                        // 偵測到物體後的操作
                        Debug.Log("Object detected!");
                        if (obj.CompareTag("Shark"))
                        {
                            // 在此處啟動你想要執行的腳本或功能
                            // 例如，調用其他組件的方法或激活其他物體
                            PC.isCKSHARK = true;
                            isObjectDetected = true;

                            
                                if (!ispressed) // 只執行一次
                                {
                                    L.checkPressNum += 1;
                                    ispressed = true;
                                }
                            

                        }
                        

                    }
                   
                }
        }
        isObjectDetected = false;
    }
}