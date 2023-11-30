using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class ViveInputMapper : MonoBehaviour
{
    public string inputButton; // 在InputManager中設置的鍵盤輸入按鈕名稱
    public SteamVR_Input_Sources inputSource; // VIVE控制器的輸入來源
    public SteamVR_Action_Boolean viveButton; // VIVE控制器上的按鈕

    private void Update()
    {
        if (viveButton.GetStateDown(inputSource))
        {
            // 在這裡處理按下VIVE控制器按鈕的相應邏輯
            // 您可以執行需要的操作，例如按下UI按鈕或執行其他功能
            PressButton();
        }
    }

    private void PressButton()
    {
        // 在這裡處理按下按鈕的相應邏輯
        // 您可以使用InputManager中設置的鍵盤輸入按鈕名稱來觸發相應的操作
       /* InputManager.Instance.PressButton(Fire);*/
    }
}