using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DamageOnCollisionVR: MonoBehaviour
{
    public int damageAmount = 10; // 傷害數量

    public AudioClip explosionSound;
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // 在這裡執行給予玩家傷害的行為，例如扣除玩家的生命值
            HealthVR playerHealth = collision.gameObject.GetComponent<HealthVR>();
            if (explosionSound != null)
            {
                GameObject audioObject = new GameObject("ExplosionSound");
                AudioSource audioSource = audioObject.AddComponent<AudioSource>();
                audioSource.clip = explosionSound;
                audioSource.volume = 0.8f;
                audioSource.Play();
                Destroy(audioObject, explosionSound.length);
            }
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
            TakeDamageScript.isFlashing = false; // 將isFlashing標記為false，停止閃爍效果
        }
    }
}
