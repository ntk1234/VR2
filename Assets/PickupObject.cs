using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class PickupObject : MonoBehaviour
{
    public SteamVR_Input_Sources type;
    public SteamVR_Behaviour_Pose controllerPose;
    public SteamVR_Action_Boolean grab;
    GameObject collidingObject;
    GameObject onHandObj;

    private void SetCollidingObject(Collider collider)
    {
        if (collidingObject || !collider.GetComponent<Rigidbody>())
        {
            return;
        }
        collidingObject = collider.gameObject;
    }

    public void OnTriggerEnter(Collider collider)
    {
        SetCollidingObject(collider);
        print("OnTriggerEnter " + collider.gameObject.name);
    }

    public void OnTriggerStay(Collider collider)
    {
        SetCollidingObject(collider);
        print("OnTriggerStay " + collider.gameObject.name);
    }

    public void OnTriggerExit(Collider collider)
    {
        if (!collidingObject)
        {
            return;
        }

        collidingObject = null;
        print("OnTriggerExit " + collider.gameObject.name);
    }

    private void GrabObject()
    {
        onHandObj = collidingObject;
        collidingObject = null;

        var joint = AddFixedJoint();
        joint.connectedBody = onHandObj.GetComponent<Rigidbody>();
    }

    //connects the controller to the object
    private FixedJoint AddFixedJoint()
    {
        FixedJoint fx = gameObject.AddComponent<FixedJoint>();
        fx.breakForce = 20000;
        fx.breakTorque = 20000;
        return fx;
    }

    private void ReleaseObject()
    {
        if (GetComponent<FixedJoint>())
        {
            GetComponent<FixedJoint>().connectedBody = null;
            Destroy(GetComponent<FixedJoint>());

            onHandObj.GetComponent<Rigidbody>().velocity = controllerPose.GetVelocity();
            onHandObj.GetComponent<Rigidbody>().angularVelocity = controllerPose.GetAngularVelocity();

        }
        onHandObj = null;
    }

    // Update is called once per frame
    void Update()
    {
        if (grab.GetLastStateDown(type))
        {
            if (collidingObject)
            {
                GrabObject();
            }
        }

        if (grab.GetLastStateUp(type))
        {
            if (onHandObj)
            {
                ReleaseObject();
            }
        }
    }
}