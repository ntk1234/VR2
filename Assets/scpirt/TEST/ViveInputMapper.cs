using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class ViveInputMapper : MonoBehaviour
{
    public string inputButton; // �bInputManager���]�m����L��J���s�W��
    public SteamVR_Input_Sources inputSource; // VIVE�������J�ӷ�
    public SteamVR_Action_Boolean viveButton; // VIVE����W�����s

    private void Update()
    {
        if (viveButton.GetStateDown(inputSource))
        {
            // �b�o�̳B�z���UVIVE������s�������޿�
            // �z�i�H����ݭn���ާ@�A�Ҧp���UUI���s�ΰ����L�\��
            PressButton();
        }
    }

    private void PressButton()
    {
        // �b�o�̳B�z���U���s�������޿�
        // �z�i�H�ϥ�InputManager���]�m����L��J���s�W�٨�Ĳ�o�������ާ@
       /* InputManager.Instance.PressButton(Fire);*/
    }
}