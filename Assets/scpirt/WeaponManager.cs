using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    public GameObject[] weapons;
    private int currentWeaponIndex = 0;
    public GameObject[] ui;
    private int currentUi = 0;
    public GameObject[] weapons2;
    private int currentWeaponIndex2 = 0;
    private void Start()
    {
        // ��ܪ�l�Z���A���è�L�Z��
        SelectWeapon(currentWeaponIndex, currentWeaponIndex2, currentUi);
    }

    private void Update()
    {
        if (Input.GetButtonDown("ChangeW"))
        {
            SwitchWeapon();
        }
    }

    private void SwitchWeapon()
    {
        // ���÷�e�Z��
        weapons[currentWeaponIndex].SetActive(false);
        weapons2[currentWeaponIndex2].SetActive(false);
        ui[currentUi].SetActive(false);
        // ������U�@�ӪZ��
        currentWeaponIndex = (currentWeaponIndex + 1) % weapons.Length;
        currentWeaponIndex2 = (currentWeaponIndex2 + 1) % weapons2.Length;
        currentUi = (currentUi + 1) % ui.Length;
        // ��ܷs���Z��
        SelectWeapon(currentWeaponIndex, currentWeaponIndex2, currentUi);
    }

    private void SelectWeapon(int weaponIndex, int weaponIndex2 ,int uiIndex)
    {
        // ��ܫ��w���ު��Z��
        weapons[weaponIndex].SetActive(true);
        weapons2[weaponIndex2].SetActive(true);
        ui[uiIndex].SetActive(true);
    }
}