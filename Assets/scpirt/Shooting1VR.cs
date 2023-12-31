﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class Shooting1VR: MonoBehaviour
{
    public GameObject bulletPrefab;          // 子彈預置物
    public Transform bulletSpawnPoint;       // 子彈生成點
    public float bulletSpeed = 10f;          // 子彈速度
    public float fireRate = 0.5f;            // 射擊頻率
    public int maxBullets = 10;              // 最大子彈數量
    public float reloadTime = 2f;            // 重新裝填時間

    private float fireTimer;                  // 射擊計時器
    private int currentBullets;               // 目前子彈數量
    private bool isReloading;                  // 是否正在重新裝填

    public Shooting1VR shooting1vr;
    public SteamVR_Input_Sources type;
    public SteamVR_Behaviour_Pose controllerPose;
    public SteamVR_Action_Boolean r;
    public SteamVR_Action_Boolean trigger;
    private void Start()
    {
        fireTimer = fireRate; // 初始時刻可以立即射擊
        currentBullets = maxBullets; // 初始時擁有最大子彈數量
        isReloading = false; // 初始時未在重新裝填
    }

    private void Update()
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
            StartCoroutine(Reload()); // °õ¦æ­«·s¸Ë¶ñ
        }
    }

    private void Fire()
    {
        // 實例化子彈並設定初始速度和方向
        GameObject bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
        Rigidbody bulletRigidbody = bullet.GetComponent<Rigidbody>();
        bulletRigidbody.velocity = bulletSpawnPoint.forward * bulletSpeed;

        // 在一段時間後銷毀子彈
        Destroy(bullet, 5f);
    }

    private IEnumerator Reload()
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
    }
}