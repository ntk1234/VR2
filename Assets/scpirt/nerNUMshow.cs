using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using s;
public class nerNUMshow : MonoBehaviour
{
    public Text netNumber;
    private Shooting shooting;

    // Start is called before the first frame update
    void Start()
    {
        shooting = FindObjectOfType<Shooting>();
    }

    // Update is called once per frame
    void Update()
    {
        netNumber.text = "Net: " + shooting.CurrentBullets;
    }
}