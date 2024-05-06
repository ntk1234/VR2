using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class DBManager : MonoBehaviour
{

    public Scoreshow sc;

    void Start()
    {
        sc = FindObjectOfType<Scoreshow>();
    }

    public void score()
    {
        int number = sc.scoreNunber;
        //txtValue.text = number.ToString();

        // Create a form object to hold the score value
        WWWForm form = new WWWForm();
        form.AddField("score", number);

        // Send a POST request to the PHP script
        string phpURL = "http://localhost/unityserver/upload_score.php";
        UnityWebRequest www = UnityWebRequest.Post(phpURL, form);
        www.SendWebRequest();
    }


}