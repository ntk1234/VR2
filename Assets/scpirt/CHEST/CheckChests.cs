using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CheckChests : MonoBehaviour
{
    public GameObject chestA;
    public GameObject chestB;
    public GameObject chestC;
    public GameObject chestMap;

    public UnityEvent onAllChestsOpened;




    // 寶箱打開時調用此方法
    public void Update()
    {
        if (chestA.activeSelf)
        {
            chestMap.SetActive(true)
            ; }
        if (chestB.activeSelf)
        {; }
        if (chestC.activeSelf)
        {; }

        // 檢查所有寶箱是否都已打開
        if (chestA.activeSelf && chestB.activeSelf && chestC.activeSelf)
        {
            // 觸發離開事件
            Debug.Log("事件ON");
            onAllChestsOpened.Invoke();
        }
    }
}