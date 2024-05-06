using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class L1Manger: MonoBehaviour
{
    public int checkPressNum = 0;
    public int rNUM;
    public Text CPSK;
    public Text showR;
    public Text showSC; 
    public GameObject canpress;
    public GameObject NextPanel;
    public Scoreshow sc;
    public bool isNestLevel = false;
    public MouseLock2 ML2;
    public gasHealth GS;



    // Start is called before the first frame update
    void Start()
    {
        isNestLevel = false;
        canpress.SetActive(false);

        sc = FindObjectOfType<Scoreshow>();
        sc.RestScore();
    }

    // Update is called once per frame
    void Update()
    {

        CPSK.text = checkPressNum + "/ 3 Shark";
        showR.text = rNUM + "/ 2 Clear Rubbishes";
        if (checkPressNum>=3&&rNUM>=2)
        {
            canpress.SetActive(true);
            PlayerPrefs.SetInt("LevelPassed", 1);
            NextPanel.SetActive(true);
            GS.isGasLock = true;
            ML2.UnlockMouse();
            showSC.text = "Score :"+sc.scoreNunber;
           if (!isNestLevel)
            { Time.timeScale = 0; }
        }
    }

   public void NextLevel()
    {
        Time.timeScale = 1;
        GS.isGasLock = false;
        isNestLevel = true;
        sc.SaveScore();
        SceneManager.LoadScene("title");
    
    }
}
