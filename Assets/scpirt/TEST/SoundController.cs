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
        // �p�⪱�a�P���餧�����Z��
        float distance = Vector3.Distance(player.position, objectToPlaySound.position);

        // �ھڶZ���p�⭵�q
        float volume = Mathf.Lerp(maxVolume, minVolume, distance / maxDistance);

        // �]�m���q
        audioSource.volume = volume;

        // �����n��
        if (!audioSource.isPlaying && distance <= maxDistance)
        {
            audioSource.Play();
        }
        // �����n��
        else if (audioSource.isPlaying && distance > maxDistance)
        {
            audioSource.Stop();
        }
    }
}