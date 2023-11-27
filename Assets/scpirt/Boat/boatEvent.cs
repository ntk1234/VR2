using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class boatEvent : MonoBehaviour
{
    public GameObject boatcheck;
    public Text boatText;
    public GameObject eventMap1;
    public bool isTextEnabled1 = true;
    // Start is called before the first frame update

    public PauseMenu1 PM;

    public bool isLeave = false;

    public GameObject btn;

    public GameObject btn2;

    public MouseLock2 ML2;
    // Update is called once per frame
    public void Update()
    {
        if (boatcheck.activeSelf) {
            if (isTextEnabled1)
            {
            eventMap1.SetActive(true);
             ML2.UnlockMouse();
             text1();
             PM.PauseGame();
            }
            if (isLeave)
            {

                eventMap1.SetActive(true);
                btn.SetActive(false);
                btn2.SetActive(true);
                text2();
                ML2.UnlockMouse();
                PM.PauseGame();
            }



        }
    }
    private void text1()
    {
        boatText.text = "You need to find three treasures"+"\n"+
            ", then return to the boat and leave"
        ;
    }
    private void text2()
    {
        boatText.text = "You can leave "
        ;
    }

    public void opText()
    {
        eventMap1.SetActive(true);
    }
    public void iscloseText()
    {
        isTextEnabled1 = false;
        

    }

    public void iscloseBA()
    {
        boatcheck.SetActive(false);
      

    }

}
