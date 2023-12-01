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
    public float rotationThreshold = 1.0f; // 調整轉向閾值
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

        // 根據觸摸板輸入計算移動方向
        Vector3 movementDirection = new Vector3(touchpadValue.x, 0f, touchpadValue.y);
        movementDirection = mainCameraTransform.TransformDirection(movementDirection);
        movementDirection.y = 0f; // 確保移動方向保持在水平平面上
        movementDirection.Normalize();
        movementDirection *= movementSpeed;

        // 應用移動
        characterController.SimpleMove(movementDirection);

        // 根據主攝像機旋轉更新角色的旋轉
        Quaternion targetRotation = Quaternion.Euler(0f, mainCameraTransform.eulerAngles.y, 0f);
        float angleDifference = Quaternion.Angle(transform.rotation, targetRotation);

        if (angleDifference > rotationThreshold)
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, Time.deltaTime * rotationSpeed);
        }
    }
}