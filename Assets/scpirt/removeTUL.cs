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
  
    public GameObject[] ui;
    private int currentUi = 0;


    // Start is called before the first frame update
    void Start()
    {
   
        SelectWeapon( currentUi);
    }

    // Update is called once per frame
    void Update()
    {
        if (r.GetStateDown(type))
        {
            SwitchWeapon(); 

           
            // 執行重新裝填
        }
       

    }
    private void SwitchWeapon()
    {
        // Hide the current weapons
      
        ui[currentUi].SetActive(false);

        // Switch to the next weapon
      
        currentUi = (currentUi + 1) % ui.Length;

        // Show the new weapons
        SelectWeapon( currentUi);
    }

    private void SelectWeapon(int uiIndex)
    {
        // Show the specified weapons
       
        ui[uiIndex].SetActive(true);
    }


}
