using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int damage = 10; // 子弹的伤害值
                            // 其他子弹的属性和行为



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
        if (collision.gameObject.CompareTag("SmallF"))
        {

            FishMovement fm = collision.gameObject.GetComponent<FishMovement>();
            fm.isWalk = false;
            Destroy(gameObject); // 碰撞到地图时销毁子弹对象
        }
        if (collision.gameObject.CompareTag("turtle"))
        {

            FishMovement fm = collision.gameObject.GetComponent<FishMovement>();
            fm.isWalk = false;
            Destroy(gameObject); // 碰撞到地图时销毁子弹对象
        }

        if (collision.gameObject.CompareTag("Shark"))
        {
            Destroy(gameObject); // 碰撞到地图时销毁子弹对象
        }
    }
}