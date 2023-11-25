using System;
using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

namespace UnityStandardAssets.Utility
{
    public class EventSystemChecker : MonoBehaviour
    {
        // Awake is called when the script instance is being loaded
        private void Awake()
        {
            if (!FindObjectOfType<EventSystem>())
            {
                GameObject obj = new GameObject("EventSystem");
                obj.AddComponent<EventSystem>();
                obj.AddComponent<StandaloneInputModule>().enabled = true;
            }
        }
    }
}