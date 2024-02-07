using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace UnityStandardAssets.Characters.ThirdPerson
{
    public class BoostShow : MonoBehaviour
    {
        public Image boostSlider;
        public CharacterFloat CF;
    // Start is called before the first frame update
    void Start()
        {

            if (boostSlider == null)
            {
                Debug.LogError("The boostSlider reference is not set.");
            }

            if (CF == null)
            {
                Debug.LogError("The CF reference is not set.");
            }
        }

        // Update is called once per frame
        void Update()
        {
            // Update the slider value to reflect the player's health percentage
            if (boostSlider != null && CF != null)
            {
                float boostPercentage = CF.jumpboost / 100f; 
                /*float healthPercentage = playerHealth.currentHealth / playerHealth.maxHealth;*/
                boostSlider.fillAmount = boostPercentage;
            }
        }
    }
}
