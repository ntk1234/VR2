using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLock2: MonoBehaviour
{
    private bool isMouseLocked = true; // �O�_��w����

    void Start()
    {
        LockMouse();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isMouseLocked)
            {
                UnlockMouse();
            }
            else
            {
                LockMouse();
            }
        }
    }

    public void LockMouse()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        isMouseLocked = true;
    }

    public void UnlockMouse()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        isMouseLocked = false;
    }
    void OnApplicationQuit()
    {
        // ���ε{�ǰh�X�ɸ��깫��
        UnlockMouse();
    }

 
}


