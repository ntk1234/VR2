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

    private bool gamePaused = false;
    public GameObject fish1;
    public GameObject fish2;
    public GameObject fish3;
    public GameObject fish4;
    private void Start()
    {
        // 订阅捕获鱼的事件
        Fish[] fishes = FindObjectsOfType<Fish>();
        foreach (Fish fish in fishes)
        {
            fish.OnFishCaught += IncreaseFishCount;
        }
    }

    private void Update()
    {

        if (fishCount == 1)
        {
            fish1.SetActive(false);
            ;
        }
        if (fishCount == 2)
        {
            fish2.SetActive(false);
            ;
        }
        if (fishCount == 3)
        {
            fish3.SetActive(false);
            ;
        }
        if (fishCount == 4)
        {
            fish4.SetActive(false);
            ;
        }
        if (gamePaused)
        {
            // 在游戏暂停时的逻辑
            // 例如禁用玩家输入、暂停游戏进行等
        }
        else
        {
            // 在游戏运行时的逻辑
            // 例如玩家控制、游戏逻辑等
        }
    }
    private void IncreaseFishCount()
    {
        fishCount++;  // 捕获到鱼，计数器加1
        Debug.Log("Fish caught! Total count: " + fishCount);

        if (fishCount >= fishCountF)
        {
            GameOver();  // 当捕获到5条鱼时，调用游戏结束方法
        }
    }

    private void GameOver()
    {
        Debug.Log("Game Over");
        Time.timeScale = 0f;
        gamePaused = true;

        nextLevelPanel.SetActive(true);
        nextLevelText.text = "Finish\nCatch fish: " + fishCount;

        StartCoroutine(LoadTitleSceneAfterDelay(2f));
        
    }

    private IEnumerator LoadTitleSceneAfterDelay(float delay)
    {
        yield return new WaitForSecondsRealtime(delay);

        Time.timeScale = 1f;
        gamePaused = false;

        SceneManager.LoadScene("titleVR");
    }

}
