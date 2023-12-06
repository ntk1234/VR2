using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public LevelManager levelManager;

    private void Start()
    {
        if (levelManager != null)
        {
            levelManager.OnAnyKey += HandleAnyKeyDown;
        }
    }

    private void HandleAnyKeyDown()
    {
        // 在按下任意按键时执行的操作逻辑
        // 例如切换到下一关卡
        LoadNextLevel();
    }

    private void LoadNextLevel()
    {
        // 获取当前场景的索引
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        // 加载下一关卡（索引+1）
        SceneManager.LoadScene(currentSceneIndex + 1);
    }
}