using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mainmeun : MonoBehaviour
{

    public void StartGame1()
    {
        SceneManager.LoadScene("L1C");
    }
    public void StartGame2()
    {
        SceneManager.LoadScene("L2C");
    }
    public void StartGame3()
    {
        SceneManager.LoadScene("L3C");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

}
