using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class L2Manger: MonoBehaviour

{
    public int numOpenbox = 0;
    public Text CPSK;
    public GameObject canpress;
    public GameObject missionbox;
    public PauseMenu1 PM;
    public MouseLock2 ML2;
    public Scoreshow sc;

    // Start is called before the first frame update
    void Start()
    {
        canpress.SetActive(false);
        sc = FindObjectOfType<Scoreshow>();

        if (//PlayerPrefs.HasKey("LevelPassed") && 
            PlayerPrefs.GetInt("LevelPassed") != 1)
        { sc.RestScore(); }
            missionbox.SetActive(true);
        PM.PauseGame();
        ML2.UnlockMouse();

    }

    // Update is called once per frame
    void Update()
    {

        CPSK.text = numOpenbox + "/ 3 Check boxs";
     if (numOpenbox >= 3)
        {
            canpress.SetActive(true);
            sc.SaveScore();
            PlayerPrefs.SetInt("LevelPassed", 2);
            PM.ResumeGame();
            SceneManager.LoadScene("L3C");
            ;
        }
    }
}
