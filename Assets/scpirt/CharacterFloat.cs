using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class CharacterFloat : MonoBehaviour
{
    public float floatForce = 3f;
    [SerializeField]
    public KeyCode floatKey = KeyCode.Space; // 默认输入键

    private bool isFloating = false;
    private Rigidbody rb;
    public bool isJump = true;
    [SerializeField] private float floatDamping = 2f;
    [SerializeField] private float moveSpeed = 5f;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void Update()
    {
        // 检测指定按键的按下
        if (isJump) { 
        if (Input.GetButtonDown("Jump"))
        {
            // 开始浮动
            isFloating = true;
            // 应用向上的浮动力
            rb.AddForce(Vector3.up * floatForce, ForceMode.Impulse);
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
        // 如果正在浮动，则应用浮动力，使角色保持浮动状态
        if (isFloating)
        {
            rb.AddForce(Vector3.up * floatForce, ForceMode.Force);
            rb.velocity *= Mathf.Clamp01(1f - floatDamping * Time.fixedDeltaTime);
        }
    }
}

#if UNITY_EDITOR
[CustomEditor(typeof(CharacterFloat))]
public class CharacterFloatEditor : Editor
{
    public override void OnInspectorGUI()
    {
        CharacterFloat characterFloat = (CharacterFloat)target;

        EditorGUILayout.Space();
        characterFloat.floatForce = EditorGUILayout.FloatField("Float Force", characterFloat.floatForce);

        EditorGUILayout.Space();
        characterFloat.floatKey = (KeyCode)EditorGUILayout.EnumPopup("Float Key", characterFloat.floatKey);

        serializedObject.ApplyModifiedProperties();
    }
}
#endif