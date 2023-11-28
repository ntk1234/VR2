using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class ControllerAction : MonoBehaviour
{
    public SteamVR_Input_Sources type;
    public SteamVR_Action_Boolean teleport;
    public SteamVR_Action_Boolean grab;

    // Update is called once per frame
    void Update()
    {
        if (GetTeleportDown())
        {
            print("Teleport " + type);
        }

        if (GetGrab())
        {
            print("Grab " + type);
        }
    }

    public bool GetTeleportDown()
    {
        return teleport.GetStateDown(type);
    }

    public bool GetGrab()
    {
        return grab.GetState(type);
    }

}
