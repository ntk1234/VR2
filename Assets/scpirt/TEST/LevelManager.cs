using UnityEngine;
using Valve.VR;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;

public class LevelManager: MonoBehaviour
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

            SceneManager.LoadScene("L1VRC");



        }
    
     }
}
