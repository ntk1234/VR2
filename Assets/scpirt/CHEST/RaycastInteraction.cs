using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastInteraction: MonoBehaviour
{
    public float raycastDistance = 3f;  // 射線的距離
    public LayerMask interactableLayer; // 可交互物體的圖層
    public KeyCode interactKey = KeyCode.F; // 調查的按鍵

    private void Update()
    {
        if (Input.GetKeyDown(interactKey))
        {
            // 發出射線檢查是否有可交互物體
            RaycastHit hit;
            if (Physics.Raycast(transform.position, transform.forward, out hit, raycastDistance, interactableLayer))
            {
                // 檢查射線擊中的物體是否為寶箱
                GameObject interactedObject = hit.collider.gameObject;
                if (interactedObject.CompareTag("Chest"))
                {
                    // 執行寶箱調查的相關邏輯
                    InteractWithChest(interactedObject);
                }
            }
        }
    }

    private void InteractWithChest(GameObject chest)
    {
        // 在這裡實現與寶箱調查相關的邏輯，例如顯示調查視窗、播放音效等
        Debug.Log("調查寶箱：" + chest.name);
    }
}