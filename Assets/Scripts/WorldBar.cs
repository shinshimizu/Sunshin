using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WorldBar : MonoBehaviour
{
    public Slider healthSlider;
    public Slider energySlider;
    public Text healthText;
    public Text energyText;

    public void SetMaxBars(int health, int energy)
    {
        healthText.text = "HP : "+ health.ToString();
        healthSlider.maxValue = health;
        healthSlider.minValue = 0;
        healthSlider.value = health;

        energyText.text = "EP : " + energy.ToString();
        energySlider.maxValue = energy;
        energySlider.minValue = 0;
        energySlider.value = energy;
    }

    public void SetHealth(int health)
    {
        if (health > healthSlider.maxValue)
        {
            health = (int)healthSlider.maxValue;
        }
        else if (health < healthSlider.minValue)
        {
            health = (int)healthSlider.minValue;
        }
        healthText.text = "HP : " + health.ToString();
        healthSlider.value = health;
    }

    public void SetEnergy(int energy)
    {
        if (energy > energySlider.maxValue)
        {
            energy = (int)energySlider.maxValue;
        }
        else if (energy < energySlider.minValue)
        {
            energy = (int)energySlider.minValue;
        }
        energyText.text = "EP : " + energy.ToString();
        energySlider.value = energy;
    }
}
