using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SchoolMovement : MonoBehaviour
{
    public GameObject fishPrefab;   // 魚的預製體
    public int fishCount = 10;      // 魚的數量
    public float swimSpeed = 2f;    // 魚的游泳速度
    public float swimRange = 5f;    // 魚的游動範圍

    private List<GameObject> fishList = new List<GameObject>();  // 存儲魚的列表

    private void Start()
    {
        // 生成魚群
        GenerateFish();
    }

    private void GenerateFish()
    {
        for (int i = 0; i < fishCount; i++)
        {
            // 在隨機位置生成一條魚
            Vector3 randomPosition = GetRandomPosition();
            GameObject fish = Instantiate(fishPrefab, randomPosition, Quaternion.identity);
            fishList.Add(fish);

            // 設置魚的游泳速度
            FishMovement fishMovement = fish.GetComponent<FishMovement>();
            fishMovement.swimSpeed = swimSpeed;
        }
    }

    private Vector3 GetRandomPosition()
    {
        // 隨機生成一個位置在範圍內的位置
        Vector2 randomCircle = Random.insideUnitCircle * swimRange;
        Vector3 randomPosition = new Vector3(randomCircle.x, 0f, randomCircle.y);
        return transform.position + randomPosition;
    }
}