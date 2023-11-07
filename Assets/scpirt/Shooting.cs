using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public GameObject bulletPrefab;          // 子弹预制体
    public Transform bulletSpawnPoint;       // 子弹生成点
    public float bulletSpeed = 10f;          // 子弹速度
    public float fireRate = 0.5f;            // 射击频率

    private float fireTimer;                  // 射击计时器

    private void Start()
    {
        fireTimer = fireRate; // 初始时刻可以立即射击
    }

    private void Update()
    {
        fireTimer += Time.deltaTime;

        if (Input.GetButtonDown("Fire1") && fireTimer >= fireRate)
        {
            Fire(); // 执行射击操作
            fireTimer = 0f; // 重置射击计时器
        }
    }

    private void Fire()
    {
        // 实例化子弹并设置其初始速度和方向
        GameObject bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
        Rigidbody bulletRigidbody = bullet.GetComponent<Rigidbody>();
        bulletRigidbody.velocity = bulletSpawnPoint.forward * bulletSpeed;

        // 在一段时间后销毁子弹
        Destroy(bullet, 5f);
    }
}