using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;


public class shootingVR: MonoBehaviour
{
    public GameObject bulletPrefab;         
    public Transform bulletSpawnPoint;

    
    public float bulletSpeed = 10f;          
    public float fireRate = 0.5f;            
    public int maxBullets = 10;              
    public float reloadTime = 2f;            

    public float fireTimer;                  
    public int currentBullets;               
    public bool isReloading;                  
    public bool isVR;

    public shootingVR shootingvr;

    public SteamVR_Input_Sources type;
    public SteamVR_Behaviour_Pose controllerPose;
    public SteamVR_Action_Boolean r;
    public SteamVR_Action_Boolean trigger;
    

    public void Start()
    {
        fireTimer = fireRate; // 初始時刻可以立即射擊
        currentBullets = maxBullets; // 初始時擁有最大子彈數量
        isReloading = false; // 初始時未在重新裝填
        isVR = UnityEngine.XR.XRSettings.isDeviceActive;
        /*Vector3 newPosition = new Vector3(200f, -500f, 200f);
        bulletSpawnPoint.position += newPosition;*/
    }

    public void Update()
    {
        fireTimer += Time.deltaTime;
        




        if (!isReloading && Input.GetButtonDown("Fire1") && fireTimer >= fireRate && currentBullets > 0)
        {
            Fire(); // 執行射擊操作
            fireTimer = 0f; // 重置射擊計時器
            currentBullets--; // 減少子彈數量
        }

        if (!isReloading && trigger.GetState(type) && fireTimer >= fireRate && currentBullets > 0)
        {
            Fire(); // 執行射擊操作
            fireTimer = 0f; // 重置射擊計時器
            currentBullets--; // 減少子彈數量
        }

        if (Input.GetButtonDown("Reload") && currentBullets < maxBullets)
        {
            StartCoroutine(Reload()); // 執行重新裝填
        }
        if (r.GetState(type) && currentBullets < maxBullets)
        {
            StartCoroutine(Reload()); // 執行重新裝填
        }

        /*bulletSpawnPoint.transform.rotation = controllerPose.transform.rotation;*/

        /* if ((trackpadInput.y < -0.5f) && currentBullets < maxBullets)
          {
              StartCoroutine(Reload()); // 執行重新裝填
          }*/
        

    }

    public void Fire()
    {
        // 實例化子彈並設定初始速度和方向
        GameObject bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
        Rigidbody bulletRigidbody = bullet.GetComponent<Rigidbody>();
        bulletRigidbody.velocity = bulletSpawnPoint.forward * bulletSpeed;

        // 在一段時間後銷毀子彈
        Destroy(bullet, 5f);
    }

    public IEnumerator Reload()
    {
        isReloading = true;

        // 顯示重新裝填中的提示或動畫等

        yield return new WaitForSeconds(reloadTime);

        currentBullets = maxBullets; // 重新裝填完成，恢復最大子彈數量
        isReloading = false;
    }
    public int CurrentBullets
    {
        get { return currentBullets; }
    }  // Start is called before the first frame update
   
}
