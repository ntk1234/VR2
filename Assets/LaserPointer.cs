using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using UnityEngine.UI;


public class LaserPointer : MonoBehaviour
{
    public SteamVR_Input_Sources type;
    public SteamVR_Behaviour_Pose controllerPose;
    public SteamVR_Action_Vector2 teleport;
    public SteamVR_Action_Boolean tri;
    public GameObject laserPrefab;
    public Transform cameraRigTransform;
    public GameObject teleportReticlePrefab;
    private GameObject reticle;
    private Transform teleportReticleTransform;
    public Transform headTransform;
    public Vector3 teleportReticleOffset;
    public LayerMask teleportMask;
    public LayerMask FindMask;
    private bool shouldTeleport;
    GameObject laser;
    Transform laserTransform;
    Vector3 hitPoint;
    public delegate void InteractDelegate(GameObject interactableObject); // 委派定義
    public static event InteractDelegate OnInteract;

    public LayerMask uiLayerMask;

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
        if (teleport.GetAxis(type).magnitude > 0)
        {
            RaycastHit hit;
            if (Physics.Raycast(controllerPose.transform.position,
                                transform.forward, out hit, 100, teleportMask))
            {
                /*hitPoint = hit.point;
                ShowLaser(hit);
                reticle.SetActive(true);
                teleportReticleTransform.position = hitPoint + teleportReticleOffset;
                shouldTeleport = true;*/
            }
        }

        else
        {
            laser.SetActive(false);
            reticle.SetActive(false);
        }
        if (tri.GetState(type))
        {
            RaycastHit hit;
            if (Physics.Raycast(controllerPose.transform.position,
                                transform.forward, out hit, 100, FindMask))
            {
                GameObject interactedObject = hit.collider.gameObject;
                if (interactedObject.CompareTag("Chest") || (interactedObject.CompareTag("Boat")))
                {
                    OnInteract?.Invoke(interactedObject);
                }

            }
        }
        else
        {
            Debug.Log("沒東西");
            laser.SetActive(false);
            reticle.SetActive(false);
        }

      
       

        if (teleport.GetAxis(type).magnitude > 0 && shouldTeleport)
        {
            Teleport();
        }

        if (tri.GetStateDown(type))
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position, transform.forward, out hit, Mathf.Infinity, uiLayerMask))
            {
                GameObject hitObject = hit.collider.gameObject;
                if (hitObject.GetComponent<Button>())
                {
                    hitObject.GetComponent<Button>().onClick.Invoke();
                }
            }
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
}
