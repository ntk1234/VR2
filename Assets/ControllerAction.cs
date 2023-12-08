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
    public SteamVR_Action_Boolean teleport2;

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
        if (GetTeleport2Down())
        {
            print("Teleport2 " + type);
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
    public bool GetTeleport2Down()
    {
        return teleport2.GetState(type); 
    }
}
