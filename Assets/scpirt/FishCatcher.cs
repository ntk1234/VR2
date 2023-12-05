using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FishCatcher : MonoBehaviour
{
    public int fishCount = 0;  // 鱼的计数器
    public int fishCountF = 5;
    public Text nextLevelText;
    public GameObject nextLevelPanel;
    public PauseMenu1 PM;
    private void Start()
    {
        // 订阅捕获鱼的事件
        Fish[] fishes = FindObjectsOfType<Fish>();
        foreach (Fish fish in fishes)
        {
            fish.OnFishCaught += IncreaseFishCount;
        }
    }

    private void IncreaseFishCount()
    {
        fishCount++;  // 捕获到鱼，计数器加1
        Debug.Log("Fish caught! Total count: " + fishCount);

        if (fishCount >= fishCountF )
        {
            GameOver();  // 当捕获到5条鱼时，调用游戏结束方法
        }
    }

    private void GameOver()
    {
        Debug.Log("Game Over");
        PM.PauseGame();
        nextLevelPanel.SetActive(true);
        nextLevelText.text = "Finish \nCatch fish: " + fishCount;

        // 在这里编写游戏结束的逻辑，例如显示游戏结束画面、停止游戏等
    }
}
