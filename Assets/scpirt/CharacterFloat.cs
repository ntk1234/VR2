using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class CharacterFloat : MonoBehaviour
{
    public float floatForce = 5f;
    [SerializeField]
    public KeyCode floatKey = KeyCode.Space; // 默认输入键

    private bool isFloating = false;
    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        // 检测指定按键的按下
        if (Input.GetKeyDown(floatKey))
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