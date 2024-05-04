using System.Collections;
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

    public L3Manger L3;
    public bool ispressed = false;

    public KeyCode captureKey = KeyCode.C;

    public int i = 0;
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
            float distance = Vector3.Distance(mainCamera.transform.position, obj.transform.position);

            if (viewPos.x > 0 && viewPos.x < 1 && viewPos.y > 0 && viewPos.y < 1 && viewPos.z > 0)
            {
                /*if (distance <= 30f)
                {
                    Debug.Log("Object detected!");*/
                    if (!isObjectDetected && CC.isTakPH)
                    {
                      
                        // 偵測到物體後的操作

                            if (obj.CompareTag("Shark")&&distance <= 30f)
                            {
                                // 在此處啟動你想要執行的腳本或功能
                                // 例如，調用其他組件的方法或激活其他物體
                                PC.isCKSHARK = true;

                             
                                
                                isObjectDetected = true;


                                if (!ispressed && i <= 0) // 只執行一次
                                {


                                    L.checkPressNum += 1;
                                    ++i;
                                    ispressed = true;
                                }

                                    else
                                    {
                                        i = 0;
                                    }
                             }
                            
                             if (obj.CompareTag("ClownFish")&&distance <= 30f)
                            {
                                // 在此處啟動你想要執行的腳本或功能
                                // 例如，調用其他組件的方法或激活其他物體
                                PC.isCKCFish = true;
                                isObjectDetected = true;


                                if (!ispressed && i <= 0) // 只執行一次
                                {


                                    // L.checkPressNum += 1;
                                    ++i;
                                    ispressed = true;
                                }
                                else
                                {
                                    i = 0;
                                }



                            }
                            if (obj.CompareTag("turtle") && distance <= 30f)
                            {
                                // 在此處啟動你想要執行的腳本或功能
                                // 例如，調用其他組件的方法或激活其他物體
                                PC.isCKTud = true;
                                isObjectDetected = true;


                                if (!ispressed && i <= 0) // 只執行一次
                                {


                                    // L.checkPressNum += 1;
                                    ++i;
                                    ispressed = true;
                                }
                                else
                                {
                                    i = 0;
                                }

                            }
                    if (obj.CompareTag("Redfish") && distance <= 200f)
                    {
                        // 在此處啟動你想要執行的腳本或功能
                        // 例如，調用其他組件的方法或激活其他物體
                        PC.isCKRf = true;



                        isObjectDetected = true;


                        if (!ispressed && i <= 0) // 只執行一次
                        {


                            L3.rfnum+= 1;
                    
                            ++i;
                            ispressed = true;
                        }

                        else
                        {
                            i = 0;
                        }
                    }
                    if (obj.CompareTag("Modfish") && distance <= 150f)
                    {
                        // 在此處啟動你想要執行的腳本或功能
                        // 例如，調用其他組件的方法或激活其他物體
                        PC.isCKMf = true;



                        isObjectDetected = true;


                        if (!ispressed && i <= 0) // 只執行一次
                        {


                            L3.mfnum += 1;
                      
                            ++i;
                            ispressed = true;
                        }

                        else
                        {
                            i = 0;
                        }
                    }
                    if (obj.CompareTag("Sfish") && distance <= 200f)
                    {
                        // 在此處啟動你想要執行的腳本或功能
                        // 例如，調用其他組件的方法或激活其他物體
                       PC.isCKSf = true;



                        isObjectDetected = true;


                        if (!ispressed && i <= 0) // 只執行一次
                        {


                            L3.sfnum += 1;
                        
                            ++i;
                            ispressed = true;
                        }

                        else
                        {
                            i = 0;
                        }
                    }




                }



                //}
            }
        }
        isObjectDetected = false;
    }
}