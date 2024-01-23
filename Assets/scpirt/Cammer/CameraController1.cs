using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraController1 : MonoBehaviour
{
    public KeyCode captureKey = KeyCode.Space; 
    public KeyCode captureKey2 = KeyCode.B; 
    public RawImage thumbnailImage; 
    private List<Texture2D> photoTextures = new List<Texture2D>(); 
    public GameObject[] photoPreviews; 
    public GameObject bk;
    public bool isOPBK = false;

    private void Start()
    {
        
        foreach (GameObject preview in photoPreviews)
        {
            preview.SetActive(false);
        }
        bk.SetActive(false);
    }

    private void Update()
    {
        if (!isOPBK && Input.GetKeyDown(captureKey))
        {
            CaptureScreenshot();
        }

        if (!isOPBK&&Input.GetKeyDown(captureKey2))
        {
            bk.SetActive(true);
            PauseGame();
            isOPBK = true;
        }
        else if (isOPBK&&Input.GetKeyDown(captureKey2))
        {
            bk.SetActive(false);
            ResumeGame();
            isOPBK = false;
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

    private IEnumerator GenerateThumbnail(string filePath)
    {
        yield return null; // 等待一帧，以确保截图保存完成

        // 读取截图图片
        byte[] imageBytes = System.IO.File.ReadAllBytes(filePath);
        Texture2D screenshotTexture = new Texture2D(2, 2);
        screenshotTexture.LoadImage(imageBytes);

        // 缩放截图以符合缩略图大小
        Texture2D resizedTexture = ScaleTexture(screenshotTexture, 128, 128);

        // 添加照片纹理到列表
        photoTextures.Add(screenshotTexture);

        // 数量超过6，删除最旧的照片
        if (photoTextures.Count > 6)
        {
            Texture2D oldestTexture = photoTextures[0];
            photoTextures.RemoveAt(0);
            Destroy(oldestTexture);
        }

        // 更新照片预览
        UpdatePhotoPreviews();

        // 显示缩略图
        thumbnailImage.texture = resizedTexture;
        thumbnailImage.gameObject.SetActive(true);

        StartCoroutine(HideThumbnailAfterDelay(3f));
    }

    private void UpdatePhotoPreviews()
    {
        for (int i = 0; i < photoTextures.Count; i++)
        {
            // 显示照片预览
            photoPreviews[i].SetActive(true);

            // 将照片纹理应用到预览的RawImage组件上
            RawImage previewImage = photoPreviews[i].GetComponent<RawImage>();
            previewImage.texture = photoTextures[i];
        }
    }

    private IEnumerator HideThumbnailAfterDelay(float delay)
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
    public void PauseGame()
    {
        Time.timeScale = 0;
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
    }
}