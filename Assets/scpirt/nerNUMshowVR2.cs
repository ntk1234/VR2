using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class nerNUMshowVR2: MonoBehaviour
{
    public Text bulNumber;
    private Shooting1VR shooting1vr;

    // Start is called before the first frame update
    void Start()
    {
        shooting1vr = FindObjectOfType<Shooting1VR>();
    }

    // Update is called once per frame
    void Update()
    {
        bulNumber.text = "bullet: " + shooting1vr.CurrentBullets;
    }
}