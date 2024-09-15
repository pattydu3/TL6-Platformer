using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Image healthBarDisplay;


    public void updateHealth(float currentHealth, float maxHealth){
        float fillAmount = currentHealth / maxHealth;
        healthBarDisplay.fillAmount = fillAmount;
    }
}
