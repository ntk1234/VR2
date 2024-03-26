using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PanCol : MonoBehaviour
{
    public GameObject pCL;
    public GameObject pCL2;
    public bool isStop = false;
    public bool isStop2 = false;
    public KeyCode captureKey2 = KeyCode.B;
    public GameObject bk;
    public bool isOPBK = false;
    public MouseLock2 ML;
    public bool isCKSHARK = false;
    public bool isCKCFish = false;
    public bool isCKTud = false;
    public GameObject imageSK1;
    public GameObject imageSK2;
    public GameObject imageCF1;
    public GameObject imageCF2;
    public GameObject imageTD1;
    public GameObject imageTD2;
    public GameObject pSK;
    public GameObject pCF;
    public GameObject pCT;
    public GameObject cftalk;
    public bool isPSK = false;
    public bool isPCF = false;
    public bool isPTD = false;
    public bool isOpenCFtalk = false;

    // Start is called before the first frame update
    void Start()
    {
        pCL.SetActive(false);
        pCL2.SetActive(false);
        bk.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (isStop)
        {
            pCL.SetActive(true);
            
        }
        else
        {
            pCL.SetActive(false);
        }

        if (isStop2)
        {
            pCL2.SetActive(true);
        }
        else
        {
           
            pCL2.SetActive(false);
        }


        if(isPSK)
        {
            pSK.SetActive(true);
        }
        else
        {
            pSK.SetActive(false);
        }
        if (isPCF)
        {
            pCF.SetActive(true);
        }
        else
        {
            pCF.SetActive(false);
        }
        if (isPTD)
        {
            pCT.SetActive(true);
        }
        else
        {
            pCT.SetActive(false);
        }

        if (!isOPBK && Input.GetKeyDown(captureKey2))
        {
            bk.SetActive(true);
            PauseGame();
            isOPBK = true;
            ML.UnlockMouse();
        }
        else if (isOPBK && Input.GetKeyDown(captureKey2))
        {
            bk.SetActive(false);
            ResumeGame();
            isOPBK = false;
            ML.LockMouse();
            if (isStop) 
                { 
            
                isStop = false;
            }
            if (isStop2)
            {
                isStop2 = false;
            }
            if (isPSK)
            {
                isPSK = false;
            }
            if (isPCF)
            {
                isPCF = false;
            }
            if (isPTD)
            {
                isPTD = false;
            }
        }

        if (isCKSHARK)
        {
            opSKINFO();

        }
        if (isCKCFish)
        {
            opCFINFO();

        }
        if (isCKTud)
        {
            opTDINFO();

        }
        if (isOpenCFtalk)
        {

            showCancatch();
        }

    }

    public void showCancatch()
    {
        cftalk.SetActive(true);

        StartCoroutine(HideThumbnailAfterDelay(3f));
    }


    private IEnumerator HideThumbnailAfterDelay(float delay)
    {

        yield return new WaitForSecondsRealtime(delay);
        isOpenCFtalk = false;
        cftalk.SetActive(false);
    }

    public void OpenCFtalk()
    {
        isOpenCFtalk = true;

    }

        public void opSKINFO()
    {
        imageSK1.SetActive(false);
        imageSK2.SetActive(true);

    }
    public void opCFINFO()
    {
        imageCF1.SetActive(false);
        imageCF2.SetActive(true);

    }
    public void opTDINFO()
    {
        imageTD1.SetActive(false);
        imageTD2.SetActive(true);

    }
    public void isCKSpt()
    {
        isStop = true;
    }

    public void isCKSpf()
    {
        isStop = false;
    }
    public void isCKSpt2()
    {
        isStop2 = true;
    }

    public void isCKSpf2()
    {
        isStop2 = false;
    }

    public void openPSK()
    {
        
        isPSK = true;
    }
    public void closePSK()
    {
        isPSK = false;
     
    }
    public void openPCF()
    {

        isPCF = true;
    }
    public void closePCF()
    {
        isPCF = false;

    }
    public void openPTD()
    {

        isPTD = true;
    }
    public void closePTD()
    {
        isPTD = false;

    }
    public void PauseGame()
    {
    Time.timeScale = 0;
    }

    public void ResumeGame()
    {
    Time.timeScale = 1;
    }

}
