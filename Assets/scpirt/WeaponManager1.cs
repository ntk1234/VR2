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
        // ��ܪ�l�Z���A���è�L�Z��
        SelectWeapon(currentWeaponIndex, currentWeaponIndex2, currentUi);
    }

    private void Update()
    {
        Vector2 trackpadInput = teleport.GetAxis(type);
        if (trackpadInput.y > 0.5f)
        {
            SwitchWeapon();
            // �b�o�̰���W�ưʪ������ާ@
            Debug.Log("�W�ư�");
        }

        // �����U�ư�
        if (trackpadInput.y < -0.5f)
        {
            // �b�o�̰���U�ưʪ������ާ@
            Debug.Log("�U�ư�");
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
    private void OnTeleportChanged(SteamVR_Action_Vector2 fromAction, SteamVR_Input_Sources fromSource, Vector2 axis, Vector2 delta)
    {
        // �b�o�̳B�z�y��O��J�Ȫ��ܤ�
    }
}