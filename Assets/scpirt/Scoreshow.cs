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
        // �qPlayerPrefs��Ū���W�@�ӳ����O�s������
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

    // �b�C�������ɫO�s���ƨ�PlayerPrefs
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

    // ��s������ܤ奻
    private void UpdateScoreText()
    {
        score.text = "Score: " + scoreNunber;
    }
}