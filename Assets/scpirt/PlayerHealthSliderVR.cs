using System.Collections;
using System.Collections.Generic;


using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthSliderVR: MonoBehaviour
{
    public Slider healthSlider;
    public HealthVR playerHealth;

    private void Start()
    {
        // Check if the references are set
        if (healthSlider == null)
        {
            Debug.LogError("The healthSlider reference is not set.");
        }

        if (playerHealth == null)
        {
            Debug.LogError("The playerHealth reference is not set.");
        }
    }

    private void Update()
    {
        // Update the slider value to reflect the player's health percentage
        if (healthSlider != null && playerHealth != null)
        {
            /*float healthPercentage = playerHealth.currentHealth / playerHealth.maxHealth;*/
            healthSlider.value = playerHealth.currentHealth;
        }
    }
}