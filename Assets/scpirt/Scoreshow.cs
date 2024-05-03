using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Scoreshow : MonoBehaviour
{
    public Text score;
    public int scoreNunber;


    // Start is called before the first frame update
    void Start()
    {
        // 從PlayerPrefs中讀取上一個場景保存的分數
        scoreNunber = PlayerPrefs.GetInt("Score", 500);
        UpdateScoreText();
    }

    // Update is called once per frame
    void Update()
    {
        if (scoreNunber < 0)
        {
            scoreNunber = 0;
        }

        UpdateScoreText();
    }

    // 在遊戲結束時保存分數到PlayerPrefs
    public void SaveScore()
    {
        PlayerPrefs.SetInt("Score", scoreNunber);
        PlayerPrefs.Save();
    }
    public void RestScore()
    {
        PlayerPrefs.SetInt("Score", 500);
        PlayerPrefs.Save();
    }

    // 更新分數顯示文本
    private void UpdateScoreText()
    {
        score.text = "Score: " + scoreNunber;
    }
}