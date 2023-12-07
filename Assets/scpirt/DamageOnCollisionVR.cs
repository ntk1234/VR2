using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DamageOnCollisionVR: MonoBehaviour
{
    public int damageAmount = 10; // �ˮ`�ƶq
    

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // �b�o�̰��浹�����a�ˮ`���欰�A�Ҧp�������a���ͩR��
            HealthVR playerHealth = collision.gameObject.GetComponent<HealthVR>();
            
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
