using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;


public class shootingVR: MonoBehaviour
{
    public GameObject bulletPrefab;          // �l�u�w�m��
    public Transform bulletSpawnPoint;       // �l�u�ͦ��I
    public float bulletSpeed = 10f;          // �l�u�t��
    public float fireRate = 0.5f;            // �g���W�v
    public int maxBullets = 10;              // �̤j�l�u�ƶq
    public float reloadTime = 2f;            // ���s�˶�ɶ�

    public float fireTimer;                  // �g���p�ɾ�
    public int currentBullets;               // �ثe�l�u�ƶq
    public bool isReloading;                  // �O�_���b���s�˶�
    public bool isVR;

    public shootingVR shootingvr;

    public SteamVR_Input_Sources type;
    public SteamVR_Behaviour_Pose controllerPose;
    public SteamVR_Action_Boolean r;
    public SteamVR_Action_Boolean trigger;

    public void Start()
    {
        fireTimer = fireRate; // ��l�ɨ�i�H�ߧY�g��
        currentBullets = maxBullets; // ��l�ɾ֦��̤j�l�u�ƶq
        isReloading = false; // ��l�ɥ��b���s�˶�
        isVR = UnityEngine.XR.XRSettings.isDeviceActive;
    }

    public void Update()
    {
        fireTimer += Time.deltaTime;
        




        if (!isReloading && Input.GetButtonDown("Fire1") && fireTimer >= fireRate && currentBullets > 0)
        {
            Fire(); // ����g���ާ@
            fireTimer = 0f; // ���m�g���p�ɾ�
            currentBullets--; // ��֤l�u�ƶq
        }

        if (!isReloading && trigger.GetState(type) && fireTimer >= fireRate && currentBullets > 0)
        {
            Fire(); // ����g���ާ@
            fireTimer = 0f; // ���m�g���p�ɾ�
            currentBullets--; // ��֤l�u�ƶq
        }

        if (Input.GetButtonDown("Reload") && currentBullets < maxBullets)
        {
            StartCoroutine(Reload()); // ���歫�s�˶�
        }




        /* if ((trackpadInput.y < -0.5f) && currentBullets < maxBullets)
          {
              StartCoroutine(Reload()); // ���歫�s�˶�
          }*/

    }

    public void Fire()
    {
        // ��ҤƤl�u�ó]�w��l�t�שM��V
        GameObject bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
        Rigidbody bulletRigidbody = bullet.GetComponent<Rigidbody>();
        bulletRigidbody.velocity = bulletSpawnPoint.forward * bulletSpeed;

        // �b�@�q�ɶ���P���l�u
        Destroy(bullet, 5f);
    }

    public IEnumerator Reload()
    {
        isReloading = true;

        // ��ܭ��s�˶񤤪����ܩΰʵe��

        yield return new WaitForSeconds(reloadTime);

        currentBullets = maxBullets; // ���s�˶񧹦��A��_�̤j�l�u�ƶq
        isReloading = false;
    }
    public int CurrentBullets
    {
        get { return currentBullets; }
    }  // Start is called before the first frame update
   
}
