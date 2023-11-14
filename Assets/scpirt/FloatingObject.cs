using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingObject : MonoBehaviour
{
    public Rigidbody rb; // 角色的Rigidbody组件的引用
    public float floatForce = 10f; // 浮力的大小
    public float waterLevel = 0f; // 水面的高度

    private bool isFloating = false; // 是否在水面上浮动

    void Start()
    {
        rb = GetComponent<Rigidbody>(); // 获取角色的Rigidbody组件
    }

    void Update()
    {
        if (transform.position.y <= waterLevel && !isFloating)
        {
            // 角色进入水面，开始浮动
            isFloating = true;
            ApplyForce(Vector3.up * floatForce);
        }
        else if (transform.position.y > waterLevel && isFloating)
        {
            // 角色离开水面，停止浮动
            isFloating = false;
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
        }
    }

    void ApplyForce(Vector3 force)
    {
        rb.AddForce(force);
    }
}