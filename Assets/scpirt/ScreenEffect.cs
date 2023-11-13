using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenEffect : MonoBehaviour
{
    public Material effectMaterial; // ���Ω�̹����S�ħ���

    public static bool isFlashing = false; // �O�_���b�{�{
    private float flashDuration = 0.1f; // �{�{������ɶ�
    private float flashTimer = 0f; // �{�{�p�ɾ�

    private void Update()
    {
        if (isFlashing)
        {
            flashTimer += Time.deltaTime;

            // �p�G�{�{�ɶ��W�L����ɶ��A�h����{�{
            if (flashTimer >= flashDuration)
            {
                StopFlashing();
            }
        }
    }

    private void OnRenderImage(RenderTexture source, RenderTexture destination)
    {
        if (isFlashing && effectMaterial != null)
        {
            // �b�̹��Wø�s����{�{�ĪG
            Graphics.Blit(source, destination, effectMaterial);
        }
        else
        {
            Graphics.Blit(source, destination);
        }
    }

    public void StartFlashing()
    {
        isFlashing = true;
        flashTimer = 0f;
    }

    public void StopFlashing()
    {
        isFlashing = false;
        flashTimer = 0f;
    }
}
