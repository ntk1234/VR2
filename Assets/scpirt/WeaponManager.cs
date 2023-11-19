using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    public GameObject[] weapons;
    private int currentWeaponIndex = 0;
    public GameObject[] ui;
    private int currentUi = 0;
    private void Start()
    {
        // ��ܪ�l�Z���A���è�L�Z��
        SelectWeapon(currentWeaponIndex,currentUi);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            SwitchWeapon();
        }
    }

    private void SwitchWeapon()
    {
        // ���÷�e�Z��
        weapons[currentWeaponIndex].SetActive(false);
        ui[currentUi].SetActive(false);
        // ������U�@�ӪZ��
        currentWeaponIndex = (currentWeaponIndex + 1) % weapons.Length;
        currentUi = (currentUi + 1) % ui.Length;
        // ��ܷs���Z��
        SelectWeapon(currentWeaponIndex, currentUi);
    }

    private void SelectWeapon(int weaponIndex,int uiIndex)
    {
        // ��ܫ��w���ު��Z��
        weapons[weaponIndex].SetActive(true);
        ui[uiIndex].SetActive(true);
    }
}