using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Valve.VR;

public class CharacterFloatVR : MonoBehaviour
{
    public float floatForce = 5f;
    public SteamVR_Input_Sources type;
    public SteamVR_Behaviour_Pose controllerPose;
    public SteamVR_Action_Boolean tri;
    private bool isFloating = false;
    public Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        // 检测指定按键的按下
        if (tri.GetStateDown(type))
        {
            // 开始浮动
            isFloating = true;
            // 应用向上的浮动力
            rb.AddForce(Vector3.up * floatForce, ForceMode.Impulse);
        }
       
    }

    private void FixedUpdate()
    {
        // 如果正在浮动，则应用浮动力，使角色保持浮动状态
        if (isFloating)
        {
            rb.AddForce(Vector3.up * floatForce, ForceMode.Force);
        }  
    }
}


