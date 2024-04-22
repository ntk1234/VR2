using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Scoreshow : MonoBehaviour
{
    public Text score;
    public  int scoreNunber;
    Scoreshow scoreshow;

    // Start is called before the first frame update
    void Start()

    {
        scoreshow = FindObjectOfType<Scoreshow>();
        scoreNunber = 500;
    }

    // Update is called once per frame
    void Update()

    {
        if (scoreNunber<0)
        {
            scoreNunber = 0;
       }
        score.text = "Score: " + scoreNunber;
    }
}