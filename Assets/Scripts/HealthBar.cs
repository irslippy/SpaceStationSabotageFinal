using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//this script controls the UI health bar for the player. Every time the player loses health
//this script updates the UI health bar
public class HealthBar : MonoBehaviour
{
    //sets health bar UI to reflect conditions in game
    public Slider slider;
    public Gradient gradient;
    public Image fill;
    public void SetMaxValue(int amount)
    {
        slider.maxValue = amount;
        slider.value = amount;

        fill.color = gradient.Evaluate(1f);
    }

    public void SetStat(int amount)
    {
        slider.value = amount;
        fill.color = gradient.Evaluate(slider.normalizedValue);
    }
}
