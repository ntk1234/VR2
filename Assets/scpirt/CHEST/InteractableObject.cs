using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObject : MonoBehaviour


{
    public GameObject chest;

    private void Start()
    {
        // 註冊調查事件的方法

        
        RaycastInteraction.OnInteract += InteractWithObject;

    }

    private void OnDestroy()
    {
        // 解除註冊調查事件的方法
        RaycastInteraction.OnInteract -= InteractWithObject;
    }

    private void InteractWithObject(GameObject interactableObject)
    {
        if (interactableObject == gameObject)
        {
            // 在這裡實現與物品調查相關的邏輯，例如顯示調查視窗、播放音效等
            Debug.Log("調查物品：" + interactableObject.name);
            chest.SetActive(true);
        }
    }
}