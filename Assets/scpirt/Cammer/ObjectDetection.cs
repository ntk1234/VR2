using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectDetection : MonoBehaviour
{
    public GameObject objectToDetect; // 要偵測的物體
    public float detectionDelay = 1f; // 偵測間隔時間

    private Camera mainCamera;
    private bool isObjectDetected = false;



    private void Start()
    {
        mainCamera = Camera.main;
        InvokeRepeating("DetectObject", detectionDelay, detectionDelay);
    }

    private void DetectObject()
    {
        Vector3 viewPos = mainCamera.WorldToViewportPoint(objectToDetect.transform.position);

        if (viewPos.x > 0 && viewPos.x < 1 && viewPos.y > 0 && viewPos.y < 1 && viewPos.z > 0)
        {
            if (!isObjectDetected )
            {
                // 偵測到物體後的操作
                Debug.Log("Object detected!");
                // 在此處啟動你想要執行的腳本或功能
                isObjectDetected = true;
            }
        }
        else
        {
            isObjectDetected = false;
        }
    }
}