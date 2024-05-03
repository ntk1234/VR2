using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLock2: MonoBehaviour
{
    private bool isMouseLocked = true; // 是否鎖定鼠標

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
        // 應用程序退出時解鎖鼠標
        UnlockMouse();
    }

 
}


