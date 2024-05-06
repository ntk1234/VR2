using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet1: MonoBehaviour
{
    public int damage = 10; // 子弹的伤害值
                            // 其他子弹的属性和行为

    public bool isShoot = false;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Map"))
        {
            Destroy(gameObject); // 碰撞到地图时销毁子弹对象
        }

        if (collision.gameObject.CompareTag("ClownFish"))
        {
            Destroy(gameObject); // 碰撞到地图时销毁子弹对象
        }
        if (collision.gameObject.CompareTag("Shark"))
        {
            SharkAI sai = collision.gameObject.GetComponent<SharkAI>();
            sai.isTATK = true;
            Destroy(gameObject); // 碰撞到地图时销毁子弹对象
        }

        if (collision.gameObject.CompareTag("R"))
        {
           

            Destroy(gameObject); // 碰撞到地图时销毁子弹对象
        }
    }
}