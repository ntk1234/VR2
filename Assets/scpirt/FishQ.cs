using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishQ : MonoBehaviour
{
    public bool isQues = false;
    // Start is called before the first frame update
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isQues) { 
        Time.timeScale = 0;

        }
        else
        {
            Time.timeScale = 1;
        }
    }

    public void closeQ()
    {

        isQues = false;
    }
}
