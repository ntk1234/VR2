using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenEffect : MonoBehaviour
{
    public Material effectMaterial; // 應用於屏幕的特效材質

    public static bool isFlashing = false; // 是否正在閃爍
    private float flashDuration = 0.1f; // 閃爍的持續時間
    private float flashTimer = 0f; // 閃爍計時器

    private void Update()
    {
        if (isFlashing)
        {
            flashTimer += Time.deltaTime;

            // 如果閃爍時間超過持續時間，則停止閃爍
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
            // 在屏幕上繪製紅色閃爍效果
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
