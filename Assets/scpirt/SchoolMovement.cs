using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SchoolMovement : MonoBehaviour
{
    public GameObject fishPrefab;   // �����w�s��
    public int fishCount = 10;      // �����ƶq
    public float swimSpeed = 2f;    // ������a�t��
    public float swimRange = 5f;    // ������ʽd��

    private List<GameObject> fishList = new List<GameObject>();  // �s�x�����C��

    private void Start()
    {
        // �ͦ����s
        GenerateFish();
    }

    private void GenerateFish()
    {
        for (int i = 0; i < fishCount; i++)
        {
            // �b�H����m�ͦ��@����
            Vector3 randomPosition = GetRandomPosition();
            GameObject fish = Instantiate(fishPrefab, randomPosition, Quaternion.identity);
            fishList.Add(fish);

            // �]�m������a�t��
            FishMovement fishMovement = fish.GetComponent<FishMovement>();
            fishMovement.swimSpeed = swimSpeed;
        }
    }

    private Vector3 GetRandomPosition()
    {
        // �H���ͦ��@�Ӧ�m�b�d�򤺪���m
        Vector2 randomCircle = Random.insideUnitCircle * swimRange;
        Vector3 randomPosition = new Vector3(randomCircle.x, 0f, randomCircle.y);
        return transform.position + randomPosition;
    }
}