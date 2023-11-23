using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObject : MonoBehaviour


{
    public GameObject chest;

    private void Start()
    {
        // ���U�լd�ƥ󪺤�k

        
        RaycastInteraction.OnInteract += InteractWithObject;

    }

    private void OnDestroy()
    {
        // �Ѱ����U�լd�ƥ󪺤�k
        RaycastInteraction.OnInteract -= InteractWithObject;
    }

    private void InteractWithObject(GameObject interactableObject)
    {
        if (interactableObject == gameObject)
        {
            // �b�o�̹�{�P���~�լd�������޿�A�Ҧp��ܽլd�����B���񭵮ĵ�
            Debug.Log("�լd���~�G" + interactableObject.name);
            chest.SetActive(true);
        }
    }
}