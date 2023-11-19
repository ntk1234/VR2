using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class nerNUMshow1: MonoBehaviour
{
    public Text bulNumber;
    private Shooting1 shooting1;

    // Start is called before the first frame update
    void Start()
    {
        shooting1 = FindObjectOfType<Shooting1>();
    }

    // Update is called once per frame
    void Update()
    {
        bulNumber.text = "bullet: " + shooting1.CurrentBullets;
    }
}