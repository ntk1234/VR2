using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddForce : MonoBehaviour
{
    public Rigidbody rb; // 角色的Rigidbody组件的引用
    public float floatForce = 10f; // 浮力的大小

    void Start()
    {
        rb = GetComponent<Rigidbody>(); // 获取角色的Rigidbody组件
    }

    void Update()
    {
        // 在Update函数中调用ApplyForce()函数以施加浮力
        ApplyForce(Vector3.up * floatForce);
    }

    void ApplyForce(Vector3 force)
    {
        rb.AddForce(force);
    }
}