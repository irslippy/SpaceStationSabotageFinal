using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//this script updates the UI shield integrity bar every time the shield is hit
public class ShieldBar : MonoBehaviour
{
    //sets shield bar UI to reflect in game conditions
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
