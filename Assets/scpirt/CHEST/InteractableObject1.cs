using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObject1: MonoBehaviour


{
    public L3Manger L3;
    public bool ispressed = false;

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
            Debug.Log("QQQQ1");
            if (!ispressed)
            {
                L3.sfnum += 1;
                ispressed = true;
            }

        }
    }
}