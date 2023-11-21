using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CheckChests: MonoBehaviour
{
    public GameObject chestA;
    public GameObject chestB;
    public GameObject chestC;

    public UnityEvent onAllChestsOpened;

    private bool chestAOpened = false;
    private bool chestBOpened = false;
    private bool chestCOpened = false;

    // 寶箱打開時調用此方法
    public void ChestOpened(GameObject chest)
    {
        if (chest == chestA)
        {
            chestAOpened = true;
        }
        else if (chest == chestB)
        {
            chestBOpened = true;
        }
        else if (chest == chestC)
        {
            chestCOpened = true;
        }

        // 檢查所有寶箱是否都已打開
        if (chestAOpened && chestBOpened && chestCOpened)
        {
            // 觸發離開事件
            onAllChestsOpened.Invoke();
        }
    }
}