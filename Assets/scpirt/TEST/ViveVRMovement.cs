using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class ViveVRMovement : MonoBehaviour
{
    public SteamVR_Input_Sources inputSource;
    public SteamVR_Action_Vector2 touchpadAxis;
    public float movementSpeed = 1.0f;
    public float rotationSpeed = 5.0f;
    public float rotationThreshold = 1.0f;
    public float stationaryThreshold = 0.1f; // 调整静止阈值
    private CharacterController characterController;
    private Transform mainCameraTransform;
    private Quaternion targetRotation;

    private void Start()
    {
        characterController = GetComponent<CharacterController>();
        mainCameraTransform = Camera.main.transform;
        targetRotation = transform.rotation;
    }

    private void Update()
    {
        Vector2 touchpadValue = touchpadAxis.GetAxis(inputSource);

        // 根据触摸板输入计算移动方向
        Vector3 movementDirection = new Vector3(touchpadValue.x, 0f, touchpadValue.y);
        movementDirection = mainCameraTransform.TransformDirection(movementDirection);
        movementDirection.y = 0f; // 确保移动方向保持在水平平面上
        movementDirection.Normalize();
        movementDirection *= movementSpeed;

        // 应用移动
        characterController.SimpleMove(movementDirection);

        // 根据主摄像机旋转更新角色的旋转
        Quaternion targetRotation = Quaternion.Euler(0f, mainCameraTransform.eulerAngles.y, 0f);
        float angleDifference = Quaternion.Angle(transform.rotation, targetRotation);

        // 检查角色的移动速度，如果小于静止阈值，则将旋转速度设置为0
        if (characterController.velocity.magnitude < stationaryThreshold)
        {
            rotationSpeed = 0f;
            movementDirection.y = 0f;
        }
        else
        {
            rotationSpeed = 5.0f; // 恢复旋转速度
        }

        if (angleDifference > rotationThreshold)
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, Time.deltaTime * rotationSpeed);
        }
    }
}