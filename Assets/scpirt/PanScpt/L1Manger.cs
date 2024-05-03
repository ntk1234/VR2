using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class L1Manger: MonoBehaviour
{
    public int checkPressNum = 0;
    public Text CPSK;
    public GameObject canpress;
    public Scoreshow sc;

    // Start is called before the first frame update
    void Start()
    {
        canpress.SetActive(false);

        sc = FindObjectOfType<Scoreshow>();
        sc.RestScore();
    }

    // Update is called once per frame
    void Update()
    {

        CPSK.text = checkPressNum + "/ 3 Shark";
     if (checkPressNum>=3)
        {
            canpress.SetActive(true);
            PlayerPrefs.SetInt("LevelPassed", 1);
            sc.SaveScore();
            SceneManager.LoadScene("L2C");
       
        }
    }
}
