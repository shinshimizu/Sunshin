using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider slider;
    public Text text;

    public void SetMaxHealth(int health)
    {
        text.text = "HP : "+ health.ToString();
        slider.maxValue = health;
        slider.value = health;
    }

    public void SetHealth(int health)
    {
        text.text = "HP : " + health.ToString();
        slider.value = health;
    }
}
