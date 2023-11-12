using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public float maxHealth = 100f; // ���󪺳̤j�ͩR��
    public float currentHealth; // ���󪺷�e�ͩR��

    private void Start()
    {
        currentHealth = maxHealth; // ��l�Ʒ�e�ͩR�Ȭ��̤j�ͩR��
    }

    // �Ө��ˮ`
    public void TakeDamage(float damage)
    {
        currentHealth -= damage; // ��ַ�e�ͩR��

        if (currentHealth <= 0f)
        {
            Die(); // �p�G��e�ͩR�Ȥp�󵥩� 0�A�h���榺�`�ʧ@
        }
    }

    // ���`
    private void Die()
    {
        // �b�o�̹�{���󦺤`�ɪ��ʧ@
        Debug.Log("Player died!");// ���B�u�O�P������A�z�i�H�ھڹC���ݨD�i��������ާ@
    }
}