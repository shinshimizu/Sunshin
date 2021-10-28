using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider healthSlider;
    public Slider energySlider;
    public Text healthText;
    public Text energyText;

    public void SetMaxHealth(int health)
    {
        healthText.text = "HP : "+ health.ToString();
        healthSlider.maxValue = health;
        healthSlider.minValue = 0;
        healthSlider.value = health;
    }

    public void SetHealth(int health)
    {
        healthText.text = "HP : " + health.ToString();
        healthSlider.value = health;
    }

    public void SetMaxEnergy(int energy)
    {
        energyText.text = "EP : " + energy.ToString();
        energySlider.maxValue = energy;
        energySlider.minValue = 0;
        energySlider.value = energy;
    }

    public void SetEnergy(int energy)
    {
        energyText.text = "EP : " + energy.ToString();
        energySlider.value = energy;
    }
}
