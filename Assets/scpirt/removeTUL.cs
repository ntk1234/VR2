using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class removeTUL : MonoBehaviour
{
    public SteamVR_Input_Sources type;
    public SteamVR_Behaviour_Pose controllerPose;
    public SteamVR_Action_Boolean r;
    public GameObject tul;
    public bool isTUL;

    // Start is called before the first frame update
    void Start()
    {
        isTUL= true;
    }

    // Update is called once per frame
    void Update()
    {
        if (r.GetState(type))
        {
            tul.SetActive(false);

           
            // 執行重新裝填
        }
       

    }

    public void tulOpen()
    {
        isTUL = true;
        ;
    }

    public void tulClose()
    {
        isTUL = false;
        ; }
}
