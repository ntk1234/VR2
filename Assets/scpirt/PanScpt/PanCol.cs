using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PanCol : MonoBehaviour
{
    public GameObject pCL;
    public GameObject pCL2;
    public GameObject pCL3;
    public bool isStop = false;
    public bool isStop2 = false;
    public bool isStop3 = false;
    public KeyCode captureKey2 = KeyCode.B;
    public GameObject bk;
    public bool isOPBK = false;
    public MouseLock2 ML;
    public bool isCKSHARK = false;
    public bool isCKCFish = false;
    public bool isCKTud = false;

    public bool isCKRf = false;
    public bool isCKMf = false;
    public bool isCKSf = false;

    public GameObject imageSK1;
    public GameObject imageSK2;
    public GameObject imageCF1;
    public GameObject imageCF2;
    public GameObject imageTD1;
    public GameObject imageTD2;

    public GameObject imageRF1;
    public GameObject imageRF2;

    public GameObject imageMF1;
    public GameObject imageMF2;

    public GameObject imageSF1;
    public GameObject imageSF2;

    public GameObject pSK;
    public GameObject pCF;
    public GameObject pCT;

    public GameObject pCRF;
    public GameObject pCMF;
    public GameObject pCSF;

    public GameObject cftalk;
    public bool isPSK = false;
    public bool isPCF = false;
    public bool isPTD = false;
    public bool isPRF = false;
    public bool isPMF = false;
    public bool isPSF = false;
    public bool isOpenCFtalk = false;

    public bool stopscf =false ;
    public bool stopscf2 = false;
    public bool stopscf3 = false;
    public bool stopscf4 = false;
    public bool stopscf5 = false;
    public bool stopscf6 = false;

    public bool allstop = false;

    public Scoreshow sc;

    // Start is called before the first frame update
    void Start()
    {
        pCL.SetActive(false);
        pCL2.SetActive(false);
        pCL3.SetActive(false);
        bk.SetActive(false);

        sc = FindObjectOfType<Scoreshow>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!allstop)
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
            if (isStop3)
            {
                pCL3.SetActive(true);
            }
            else
            {

                pCL3.SetActive(false);
            }


            if (isPSK)
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

            //        public bool isPRF = false;
            //public bool isPMF = false;
            //  public bool isPSF = false;
            // public GameObject pCRF;
            //  public GameObject pCMF;
            //  public GameObject pCSF;

            if (isPRF)
            {
                pCRF.SetActive(true);
            }
            else
            {
                pCRF.SetActive(false);
            }
            if (isPMF)
            {
                pCMF.SetActive(true);
            }
            else
            {
                pCMF.SetActive(false);
            }
            if (isPSF)
            {
                pCSF.SetActive(true);
            }
            else
            {
                pCSF.SetActive(false);
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

                if (isStop3)
                {
                    isStop3 = false;
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

                // public bool isPRF = false;
                // public bool isPMF = false;
                //public bool isPSF = false;

                if (isPRF)
                {
                    isPRF = false;
                }
                if (isPMF)
                {
                    isPTD = false;
                }
                if (isPSF)
                {
                    isPSF = false;
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


            if (isCKRf)
            {
                opRFINFO();

            }
            if (isCKMf)
            {
                opMFINFO();

            }
            if (isCKSf)
            {
                opSFINFO();

            }




            if (isOpenCFtalk)
            {

                showCancatch();
            }

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
        if (!stopscf)
        {
            imageSK1.SetActive(false);
            imageSK2.SetActive(true);
            sc.scoreNunber += 1000;
            stopscf = true;
        }

    }
    public void opCFINFO()

    {
        if (!stopscf2)
        {
            imageCF1.SetActive(false);
        imageCF2.SetActive(true);
            sc.scoreNunber += 1000;
            stopscf2 = true;
        }

    }
    public void opTDINFO()

    {
        if (!stopscf3)
        {
            imageTD1.SetActive(false);
        imageTD2.SetActive(true);
        sc.scoreNunber += 1000;
        stopscf3 = true;
        }

    }

    public void opRFINFO()

    {
        if (!stopscf4)
        {
            imageRF1.SetActive(false);
            imageRF2.SetActive(true);
            sc.scoreNunber += 1000;
            stopscf4 = true;
        }

    }
    public void opMFINFO()

    {
        if (!stopscf5)
        {
            imageMF1.SetActive(false);
            imageMF2.SetActive(true);
            sc.scoreNunber += 1000;
            stopscf5 = true;
        }

    }
    public void opSFINFO()

    {
        if (!stopscf6)
        {
            imageSF1.SetActive(false);
            imageSF2.SetActive(true);
            sc.scoreNunber += 1000;
            stopscf6 = true;
        }

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

    public void isCKSpt3()
    {
        isStop3 = true;
    }

    public void isCKSpf3()
    {
        isStop3 = false;
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

  //  public bool isPRF = false;
   // public bool isPMF = false;
   // public bool isPSF = false;

    public void openPRF()
    {

        isPRF = true;
    }
    public void closePRF()
    {
        isPRF = false;

    }
    public void openPMF()
    {

        isPMF = true;
    }
    public void closePMF()
    {
        isPMF = false;

    }
    public void openPSF()
    {

        isPSF = true;
    }
    public void closePSF()
    {
        isPSF = false;

    }

    public void Allrun()
    {
        allstop = false;
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
