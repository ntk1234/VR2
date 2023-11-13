using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DamageOnCollision : MonoBehaviour
{
    public int damageAmount = 10; // �ˮ`�ƶq
    

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // �b�o�̰��浹�����a�ˮ`���欰�A�Ҧp�������a���ͩR��
            Health playerHealth = collision.gameObject.GetComponent<Health>();
            
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(damageAmount);
                
            }
            TakeDamageScript.isFlashing = true;

        }
      


    }

    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            TakeDamageScript.isFlashing = false; // �NisFlashing�аO��false�A����{�{�ĪG
        }
    }
}
