using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirePointConverter: MonoBehaviour
{
    private string currentFirePoint = "left";

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            ConvertFirePoint();
        }
    }

    private void ConvertFirePoint()
    {
        string convertedFirePoint = "";

        if (currentFirePoint.ToLower() == "left")
        {
            convertedFirePoint = "right";
        }
        else if (currentFirePoint.ToLower() == "right")
        {
            convertedFirePoint = "left";
        }
        else
        {
            Debug.Log("Invalid fire point!");
            return;
        }

        Debug.Log("Converted fire point: " + convertedFirePoint);
        currentFirePoint = convertedFirePoint;
    }
}
