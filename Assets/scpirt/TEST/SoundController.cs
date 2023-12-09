using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip SwimSound;
    public Transform player;
    public Transform objectToPlaySound;
    public float maxDistance = 10f;
    public float minVolume = 0.1f;
    public float maxVolume = 1f;

    public void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = SwimSound;
    }


    private void Update()
    {
        // 計算玩家與物體之間的距離
        float distance = Vector3.Distance(player.position, objectToPlaySound.position);

        // 根據距離計算音量
        float volume = Mathf.Lerp(maxVolume, minVolume, distance / maxDistance);

        // 設置音量
        audioSource.volume = volume;

        // 播放聲音
        if (!audioSource.isPlaying && distance <= maxDistance)
        {
            audioSource.Play();
        }
        // 停止聲音
        else if (audioSource.isPlaying && distance > maxDistance)
        {
            audioSource.Stop();
        }
    }
}