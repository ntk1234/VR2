using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Valve.VR;

public class VRUIController : MonoBehaviour
{
    public SteamVR_Behaviour_Pose controllerPose;
    public SteamVR_Input_Sources inputSource;
    public SteamVR_Action_Boolean interactAction;
    public LayerMask uiLayerMask;

    private Button currentButton;
    

    void Update()
    {
        if (interactAction.GetStateDown(inputSource))
        {
            if (IsPointerOverUI())
            {
                currentButton = GetPointerOverButton();
                if (currentButton != null)
                {
                    currentButton.onClick.Invoke();
                }
            }
        }
        else if (interactAction.GetStateUp(inputSource))
        {
            if (currentButton != null)
            {
                currentButton.onClick.Invoke();
                currentButton = null;
            }
        }
    }

    bool IsPointerOverUI()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, Mathf.Infinity, uiLayerMask))
        {
            return true;
        }

        return false;
    }

    Button GetPointerOverButton()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, Mathf.Infinity, uiLayerMask))
        {
            Button button = hit.collider.GetComponent<Button>();
            return button;
        }

        return null;
    }
}