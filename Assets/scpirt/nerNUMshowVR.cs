using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class nerNUMshowVR: MonoBehaviour
{
    public Text netNumber;
    public shootingVR shootingvr;

    // Start is called before the first frame update
    void Start()
    {
        shootingvr = FindObjectOfType<shootingVR>();
    }

    // Update is called once per frame
    void Update()
    {
        netNumber.text = "Net: " + shootingvr.CurrentBullets;
    }
}