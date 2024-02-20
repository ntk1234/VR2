using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using DG.Tweening;
namespace UnityStandardAssets.Characters.ThirdPerson
{
    public class CharacterFloat : MonoBehaviour
    {

        public float jbCost;
        public float reCost;
        public float fallSpeed = 0.5f;

        public float floatForce = 3f;
       
        public KeyCode floatKey = KeyCode.Space; 

        private bool isFloating = false;
        private Rigidbody rb;
        public bool isJump = true;
        [SerializeField] private float floatDamping = 2f;
        [SerializeField] private float moveSpeed = 5f;
        public float sjumpboost = 100f;
        public float jumpboost ;
        public ThirdPersonCharacter TP;
        public GameObject BSL;
        //public float captureDelay = 0.1f; // 按鍵按下的延遲時間

        //private float lastCaptureTime; // 上次按鍵按下的時間

        public void Start()
        {
            BSL.SetActive(false);
            rb = GetComponent<Rigidbody>();
            jumpboost = sjumpboost;
            jbCost = 5f;
            reCost = 0.05f;
            TP = FindObjectOfType<ThirdPersonCharacter>();

        }

        public void Update()
        {
            //Debug.Log("JBOOT" + jumpboost);
            // 检测指定按键的按下
            if (isJump)
            {
                
                if(TP.m_IsGrounded)
                {

                    jumpboost += reCost;
                    isFloating = false;

                }
                if (TP.m_IsGrounded&&jumpboost >= 100)
                {
                    BSL.SetActive(false);
                }
               
                if (jumpboost >= 100)
                {
                    jumpboost = 100;
                }
                if (jumpboost <= 0)
                {

                    isFloating = false;
                    rb.velocity = new Vector3(rb.velocity.x, -fallSpeed * 0.5f, rb.velocity.z); // 較慢的下降速度
                                                                                                // 玩家可以控制下降方向
                    float horizontalInput = Input.GetAxis("Horizontal");
                    float verticalInput = Input.GetAxis("Vertical");
                    Vector3 movement = new Vector3(horizontalInput, 0f, verticalInput) * moveSpeed * Time.deltaTime;
                    transform.Translate(movement);

                    jumpboost = 0;
                }

            }

            if (isFloating)
            {
                float horizontalInput = Input.GetAxis("Horizontal");
                float verticalInput = Input.GetAxis("Vertical");
                Vector3 movement = new Vector3(horizontalInput, 0f, verticalInput) * moveSpeed * Time.deltaTime;
                transform.Translate(movement);
            }
           
                
            
        }

        public void FixedUpdate()
        {
            if (Input.GetKeyDown(floatKey) /*&& Time.time - lastCaptureTime > captureDelay*/)
            {
                if (!BSL.activeSelf)
                {
                    var canvasGroup = BSL.GetComponent<CanvasGroup>();
                    canvasGroup.alpha = 0f;
                    canvasGroup.DOFade(3f, 1f);
                }
                BSL.SetActive(true);
                // 开始浮动
                isFloating = true;
                // 应用向上的浮动力
                rb.AddForce(Vector3.up * floatForce, ForceMode.Impulse);

                jumpboost -= jbCost;
                //lastCaptureTime = Time.time;

            }
            // 如果正在浮动，则应用浮动力，使角色保持浮动状态
            if (isFloating)
            {
                rb.AddForce(Vector3.up * floatForce, ForceMode.Force);
                rb.velocity *= Mathf.Clamp01(1f - floatDamping * Time.fixedDeltaTime);
            }
        }
    }

}



