using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//I made this script before the individual Health and Shield UI scripts. 
//They are both based off of this script 
public class UIStatBarScript : MonoBehaviour
{

    public Slider slider;
    public Gradient gradient;
    public Image fill;
    public void SetMaxValue (int amount)
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
