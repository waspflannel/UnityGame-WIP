using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnergyBar : MonoBehaviour
{
    public Slider slider;
    public Image fill;
    public RectTransform rt;
    public float SCALE = 1;

    public void setEnergy(float energy){
        slider.value = energy;
    }

    public void setMaxEnergy(float energy){
            slider.maxValue = energy;
            slider.value = energy;
    }

    public void addEnergy(float energy){
        rt.sizeDelta = new Vector2 (rt.sizeDelta.x + energy*SCALE, rt.sizeDelta.y);
        rt.localPosition = new Vector3(rt.localPosition.x + energy*SCALE/2,rt.localPosition.y,rt.localPosition.z);
    }

    public void changeMaxEnergy(float energy, float currEnergy){
        slider.maxValue = energy;
        setEnergy(currEnergy);
    }
}