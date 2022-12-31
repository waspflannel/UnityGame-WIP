using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManaBar : MonoBehaviour
{
    public Slider slider;
    public Image fill;
    public RectTransform rt;
    public float SCALE = 1;

    public void setMana(int mana){
        slider.value = mana;
    }

    public void setMaxMana(int mana){
            slider.maxValue = mana;
            slider.value = mana;
    }

    public void addMana(int mana){
        rt.sizeDelta = new Vector2 (rt.sizeDelta.x + mana*SCALE, rt.sizeDelta.y);
        rt.localPosition = new Vector3(rt.localPosition.x + mana*SCALE/2,rt.localPosition.y,rt.localPosition.z);
    }

    public void changeMaxMana(int mana, int currMana){
        slider.maxValue = mana;
        setMana(currMana);
    }
}
