using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PhotoPreview : MonoBehaviour
{
    public RectTransform panel; // Panel的RectTransform元件
    public RawImage imagePrefab; // 圖片的預製體

    private void Start()
    {
        // 在Start方法中示例化多個圖片預製體
        for (int i = 0; i < 6; i++) // 假設有3張照片
        {
            InstantiateImage();
        }
    }

    private void InstantiateImage()
    {
        // 實例化圖片預製體
        RawImage image = Instantiate(imagePrefab, panel);

        // 設置圖片預製體的大小和位置
        image.rectTransform.sizeDelta = new Vector2(200, 200); // 設置圖片大小
        image.rectTransform.localPosition = Vector3.zero; // 設置圖片位置

        // 設置圖片的Sprite（這裡假設你有獲取照片的方法）
        Texture2D photoTexture = GetPhotoTexture(); // 假設有獲取照片的方法
        image.texture = photoTexture;
    }

    private Texture2D GetPhotoTexture()
    {
        // 假設這裡有獲取照片的邏輯，並返回一個Texture2D的照片紋理
        // 可以根據實際情況自行實現
        return null;
    }

    public void SetImageTexture(Texture2D texture)
    {
        RawImage image = Instantiate(imagePrefab, panel);
        image.rectTransform.sizeDelta = new Vector2(200, 200);
        image.rectTransform.localPosition = Vector3.zero;
        image.texture = texture;
    }
}
