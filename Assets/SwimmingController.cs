using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwimmingController: MonoBehaviour
{
    public float swimSpeed = 5f; // 游泳速度
    public float floatForce = 3f; // 向上浮動的力量

    private CharacterController characterController;
    private Vector3 moveDirection = Vector3.zero;
    private bool isUnderwater = false;
    private bool isFloating = false;

    private void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        // 獲取玩家的輸入
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // 檢測是否在水下
        if (isUnderwater)
        {
            // 計算移動方向
            Vector3 forwardMovement = transform.forward * verticalInput * swimSpeed;
            Vector3 horizontalMovement = transform.right * horizontalInput * swimSpeed;
            moveDirection = forwardMovement + horizontalMovement;

            // 應用向上浮動的力量
            if (isFloating)
            {
                moveDirection.y += floatForce;
            }

            // 應用移動
            characterController.Move(moveDirection * Time.deltaTime);
        }

        // 檢測空格鍵的按下事件
        if (Input.GetKeyDown(KeyCode.Space))
        {
            isFloating = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Water"))
        {
            isUnderwater = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Water"))
        {
            isUnderwater = false;
            isFloating = false; // 離開水面時停止浮動
        }
    }
}
