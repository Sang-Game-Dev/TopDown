using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManaBar : MonoBehaviour
{
    public Slider slider;
    public void SetMaxMP(int health)
    {
        slider.maxValue = health;
        slider.value = health;
    }
    public void SetMP(int health)
    {
        slider.value = health;
    }



}
