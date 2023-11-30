using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using s;

public class LaserPointer1: MonoBehaviour 
{
    public SteamVR_Input_Sources type;
    public SteamVR_Behaviour_Pose controllerPose;
    public SteamVR_Action_Boolean teleport;
    public GameObject laserPrefab;
    public Transform cameraRigTransform;
    public GameObject teleportReticlePrefab;
    private GameObject reticle;
    private Transform teleportReticleTransform;
    public Transform headTransform;
    public Vector3 teleportReticleOffset;
    public LayerMask teleportMask;
    private bool shouldTeleport;
    GameObject laser;
    Transform laserTransform;
    Vector3 hitPoint;

    public Shooting shooting;

    public string inputButton; // 在InputManager中設置的鍵盤輸入按鈕名稱
    public SteamVR_Action_Boolean tri; //
    // Start is called before the first frame update
    void Start()
    {
        laser = Instantiate(laserPrefab);
        laserTransform = laser.transform;
        reticle = Instantiate(teleportReticlePrefab);
        teleportReticleTransform = reticle.transform;
    }


    // Update is called once per frame
    void Update()
    {
        if (teleport.GetState(type))
        {
            RaycastHit hit;
            if (Physics.Raycast(controllerPose.transform.position,
                                transform.forward, out hit, 100, teleportMask))
            {
                hitPoint = hit.point;
                ShowLaser(hit);
                reticle.SetActive(true);
                teleportReticleTransform.position = hitPoint + teleportReticleOffset;
                shouldTeleport = true;
            }
        }
        else
        {
            laser.SetActive(false);
            reticle.SetActive(false);
        }

        if (teleport.GetStateUp(type) && shouldTeleport)
        {
            /*
            Teleport(); // 減少子彈數量?\*/
        }
    }



    private void Teleport()
    {
        shouldTeleport = false;
        reticle.SetActive(false);
        Vector3 difference = cameraRigTransform.position - headTransform.position;
        difference.y = 1;  //y=0 camera?view will below plane
        cameraRigTransform.position = hitPoint + difference;
    }


    private void ShowLaser(RaycastHit hit)
    {
        laser.SetActive(true);
        laserTransform.position = Vector3.Lerp(controllerPose.transform.position, hitPoint, .5f);
        laserTransform.LookAt(hitPoint);
        laserTransform.localScale = new Vector3(laserTransform.localScale.x,
                                                laserTransform.localScale.y,
                                                hit.distance);
    }
    private void PressButton()
    {
        // 在這裡處理按下按鈕的相應邏輯
        // 您可以使用InputManager中設置的鍵盤輸入按鈕名稱來觸發相應的操作
        /*InputManager.Instance.PressButton(inputButton);*/
    }
}
