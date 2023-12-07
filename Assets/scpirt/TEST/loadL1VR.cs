using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Valve.VR;

public class loadL1VR : MonoBehaviour
{
    public SteamVR_Input_Sources type;
    public SteamVR_Behaviour_Pose controllerPose;
    public SteamVR_Action_Boolean tri;


    private void Start()
    {

    }

    private void Update()
    {


        if (tri.GetState(type))
        {

            SceneManager.LoadScene("L1VR");



        }

    }
}
