using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class L3Manger: MonoBehaviour

{
    public int rfnum = 0;
    public int mfnum = 0;
    public int sfnum = 0;
    public Text CPSK;
    public Text CPSK2;
    public Text CPSK3;
    public GameObject canpress;
    public GameObject missionbox;
    public PauseMenu1 PM;
    public MouseLock2 ML2;
    public Scoreshow sc;

    public bool isupdatescoreA=false;
    public bool isupdatescoreB = false;
    public bool isupdatescoreC = false;

    // Start is called before the first frame update
    void Start()
    {
        canpress.SetActive(false);
        sc = FindObjectOfType<Scoreshow>();

        if (//PlayerPrefs.HasKey("LevelPassed") && 
            PlayerPrefs.GetInt("LevelPassed") != 2)
        { sc.RestScore(); }
            missionbox.SetActive(true);
        PM.PauseGame();
        ML2.UnlockMouse();

    }

    // Update is called once per frame
    void Update()
    {
        if(rfnum>1)
        {
            rfnum = 1;
            if (!isupdatescoreA)
            {
                sc.scoreNunber += 500;
            }
            isupdatescoreA = true;
        }
        if (mfnum > 1)
        {
            mfnum = 1;
            if (!isupdatescoreB)
            {
                sc.scoreNunber += 500;
            }
            isupdatescoreB = true;
        }
        if (sfnum > 1)
        {
            sfnum = 1;
            if (!isupdatescoreC)
            {
                sc.scoreNunber += 500;
            }
            isupdatescoreC = true;
        }
        CPSK.text = rfnum + "/ 1 red snapper";
        CPSK2.text = mfnum + "/ 1 Mottled spinefoot";
        CPSK3.text = sfnum + "/ 1 pomfret";
        if (rfnum>=1 && mfnum>=1&& sfnum>=1)
        {
            canpress.SetActive(true);
            sc.SaveScore();
            PlayerPrefs.SetInt("LevelPassed", 3);
            PM.ResumeGame();
            ML2.UnlockMouse();
            SceneManager.LoadScene("title");
            ;
        }
    }
}
