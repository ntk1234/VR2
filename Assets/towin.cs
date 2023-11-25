using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class towin : MonoBehaviour
{


void OnTriggerEnter(Collider other)
{
    if (other.gameObject.CompareTag("Player"))
    {
        SceneManager.LoadScene("WIN");
    }
}
}
