using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class WeaponManager1: MonoBehaviour
{
    public GameObject[] weapons;
    private int currentWeaponIndex = 0;
    public GameObject[] ui;
    private int currentUi = 0;
    public GameObject[] weapons2;
    private int currentWeaponIndex2 = 0;
    public SteamVR_Input_Sources type;
    
    public SteamVR_Action_Vector2 teleport;
    public Vector2 fixedPosition;

    private void Start()
    {
        // 顯示初始武器，隱藏其他武器
        SelectWeapon(currentWeaponIndex, currentWeaponIndex2, currentUi);
    }

    private void Update()
    {
        Vector2 trackpadInput = GetAxis(type);
        if (trackpadInput!= Vector2.zero)
        {
            teleport.axis = fixedPosition;
        }
        if (Input.GetButtonDown("ChangeW"))
        {
            SwitchWeapon();
        }

        /*if (trigger.GetState(type))
        {
            SwitchWeapon();
        }*/
    }

    private void SwitchWeapon()
    {
        // 隱藏當前武器
        weapons[currentWeaponIndex].SetActive(false);
        weapons2[currentWeaponIndex2].SetActive(false);
        ui[currentUi].SetActive(false);
        // 切換到下一個武器
        currentWeaponIndex = (currentWeaponIndex + 1) % weapons.Length;
        currentWeaponIndex2 = (currentWeaponIndex2 + 1) % weapons2.Length;
        currentUi = (currentUi + 1) % ui.Length;
        // 顯示新的武器
        SelectWeapon(currentWeaponIndex, currentWeaponIndex2, currentUi);
    }

    private void SelectWeapon(int weaponIndex, int weaponIndex2 ,int uiIndex)
    {
        // 顯示指定索引的武器
        weapons[weaponIndex].SetActive(true);
        weapons2[weaponIndex2].SetActive(true);
        ui[uiIndex].SetActive(true);
    }
}