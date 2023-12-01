using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class WeaponManager1 : MonoBehaviour
{
    public GameObject[] weapons;
    private int currentWeaponIndex = 0;
    public GameObject[] ui;
    private int currentUi = 0;
    public GameObject[] weapons2;
    private int currentWeaponIndex2 = 0;
    public SteamVR_Input_Sources type;

    public SteamVR_Action_Boolean teleport2;
    public Vector2 fixedPosition;

    private bool touchpadPressed = false;

    private void Start()
    {
        // Show the initial weapon and hide others
        SelectWeapon(currentWeaponIndex, currentWeaponIndex2, currentUi);
    }

    private void Update()
    {
       /* Vector2 trackpadInput = teleport.GetAxis(type);*/

        if (!touchpadPressed && teleport2.GetStateDown(type))
        {
            /*touchpadPressed = true;*/
            SwitchWeapon();
            Debug.Log("Up swipe");
        }
        if (Input.GetButtonDown("ChangeW"))
        {
            SwitchWeapon();
        }

        /*if (trackpadInput.y <= 0.5f)
        {
            touchpadPressed = false;
        }*/

        // Detect other input or button presses
    }

    private void SwitchWeapon()
    {
        // Hide the current weapons
        weapons[currentWeaponIndex].SetActive(false);
        weapons2[currentWeaponIndex2].SetActive(false);
        ui[currentUi].SetActive(false);

        // Switch to the next weapon
        currentWeaponIndex = (currentWeaponIndex + 1) % weapons.Length;
        currentWeaponIndex2 = (currentWeaponIndex2 + 1) % weapons2.Length;
        currentUi = (currentUi + 1) % ui.Length;

        // Show the new weapons
        SelectWeapon(currentWeaponIndex, currentWeaponIndex2, currentUi);
    }

    private void SelectWeapon(int weaponIndex, int weaponIndex2, int uiIndex)
    {
        // Show the specified weapons
        weapons[weaponIndex].SetActive(true);
        weapons2[weaponIndex2].SetActive(true);
        ui[uiIndex].SetActive(true);
    }
}