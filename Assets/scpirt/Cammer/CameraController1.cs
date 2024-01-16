using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class CameraController1: MonoBehaviour
{
    public KeyCode captureKey = KeyCode.Space; // 定義拍照按鍵
    public RawImage thumbnailImage; // 顯示縮圖的RawImage元件
    
    private Texture2D thumbnailTexture;

    private void Start()
    {
        thumbnailTexture = new Texture2D(128, 128); // 縮圖的寬度和高度
    }

    private void Update()
    {
        if (Input.GetKeyDown(captureKey))
        {
            CaptureScreenshot();
        }
    }

    private void CaptureScreenshot()
    {
        string fileName = "screenshot.png";
        string filePath = System.IO.Path.Combine(Application.persistentDataPath, fileName);

        ScreenCapture.CaptureScreenshot(filePath);
        Debug.Log("Screenshot captured: " + filePath);

        StartCoroutine(GenerateThumbnail(filePath));
    }

    private System.Collections.IEnumerator GenerateThumbnail(string filePath)
    {
        // 等待一幀，以確保截圖保存完成
        yield return null;

        // 讀取截圖圖片
        byte[] imageBytes = System.IO.File.ReadAllBytes(filePath);
        Texture2D screenshotTexture = new Texture2D(2, 2);
        screenshotTexture.LoadImage(imageBytes);

        // 縮放截圖以符合縮圖大小
        Texture2D resizedTexture = ScaleTexture(screenshotTexture, 128, 128);

        // 將縮放後的圖片複製到縮圖
        thumbnailTexture.LoadRawTextureData(resizedTexture.GetRawTextureData());
        thumbnailTexture.Apply();

        // 顯示縮圖
        thumbnailImage.texture = thumbnailTexture;
        thumbnailImage.gameObject.SetActive(true);
        StartCoroutine(LoadTitleSceneAfterDelayCap(3f));
    }
    private IEnumerator LoadTitleSceneAfterDelayCap(float delay)
    {
        yield return new WaitForSecondsRealtime(delay);
        thumbnailImage.gameObject.SetActive(false);

    }
    private Texture2D ScaleTexture(Texture2D sourceTexture, int targetWidth, int targetHeight)
    {
        RenderTexture rt = new RenderTexture(targetWidth, targetHeight, 24);
        RenderTexture.active = rt;

        Graphics.Blit(sourceTexture, rt);

        Texture2D targetTexture = new Texture2D(targetWidth, targetHeight);
        targetTexture.ReadPixels(new Rect(0, 0, targetWidth, targetHeight), 0, 0);
        targetTexture.Apply();

        RenderTexture.active = null;
        Destroy(rt);

        return targetTexture;
    }
}