using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace UnityStandardAssets.Characters.ThirdPerson
{
    public class gassShow : MonoBehaviour
    {
        public Image gassSlider;
        public gasHealth CF;
        public Text GSSK;
        // Start is called before the first frame update
        void Start()
        {

            if (gassSlider == null)
            {
                Debug.LogError("The gassSlider reference is not set.");
            }

            if (CF == null)
            {
                Debug.LogError("The gass reference is not set.");
            }
            
        }

        // Update is called once per frame
        void Update()
        {
            GSSK.text = (int)CF.currentHealth + "%";
            // Update the slider value to reflect the player's health percentage
            if (gassSlider != null && CF != null)
            {
                float boostPercentage = CF.currentHealth / 100f; 
                /*float healthPercentage = playerHealth.currentHealth / playerHealth.maxHealth;*/
                gassSlider.fillAmount = boostPercentage;
            }
        }
    }
}
