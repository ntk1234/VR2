using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

[ExecuteInEditMode]
[RequireComponent(typeof(Camera))]
public class RedFlashEffect : MonoBehaviour
{
    public Material redFlashMaterial;
    public Color flashColor;
    public float flashIntensity = 1f;

    private void OnRenderImage(RenderTexture source, RenderTexture destination)
    {
        redFlashMaterial.SetColor("_FlashColor", flashColor * flashIntensity);
        Graphics.Blit(source, destination, redFlashMaterial);
    }
}