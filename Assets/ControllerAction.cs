using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class ControllerAction : MonoBehaviour
{
    public SteamVR_Input_Sources type;
    public SteamVR_Action_Vector2 teleport;
    public SteamVR_Action_Boolean grab;
    public SteamVR_Action_Boolean trigger;

    // Update is called once per frame
    void Update()
    {
        if (GetTeleportDown().magnitude > 0.1f)
        {
            print("Teleport " + type);
        }

        if (GetGrab())
        {
            print("Grab " + type);
        }
        if (GetTriggerDown())
        {
            print("trigger " + type);
        }
    }

    public Vector2 GetTeleportDown()
    {
        return teleport.GetAxis(type);
    }

    public bool GetGrab()
    {
        return grab.GetState(type);
    }
    public bool GetTriggerDown()
    {
        return trigger.GetStateDown(type);
    }
}
