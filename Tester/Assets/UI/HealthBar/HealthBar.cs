using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HealthBar : MonoBehaviour
{
    public Slider slider;
    public Gradient gradient;
    public Image fill;
    public RectTransform rt;

    [SerializeField]
    private TextMeshProUGUI text;
    
    float xCord;
    public float SCALE = 1;
    public int i = 0;
    private int flashes = 0;


    [SerializeField] int waitTime = 20;

    void Update()
    {
        text.SetText($"{GameObject.Find("Player").GetComponent<PlayerInfo>().currentHealth}/{GameObject.Find("Player").GetComponent<PlayerInfo>().maxHealth}");
        if(i<waitTime)
            i++;
        if(i == waitTime && flashes > 0){
            fill.enabled = !fill.enabled;
            i=0;
            flashes--;
        }
    }
    public void flash()
    {
        fill.enabled = !fill.enabled;
        i=0;
        flashes = 5;
        GameObject.Find("Player").GetComponent<PlayerInfo>().vulnerable = 30;
    }


    public void setHealth(int health){
        slider.value = health;
        fill.color = gradient.Evaluate(slider.normalizedValue);
    }

    public void setMaxHealth(int health){
            slider.maxValue = health;
            slider.value = health;

            fill.color = gradient.Evaluate(1f);
    }

    public void addHealth(int health){
        rt.sizeDelta = new Vector2 (rt.sizeDelta.x + health*SCALE, rt.sizeDelta.y);
        rt.localPosition = new Vector3(rt.localPosition.x + health*SCALE/2,rt.localPosition.y,rt.localPosition.z);
    }

    public void changeMaxHealth(int health, int currHealth){
        slider.maxValue = health;
        setHealth(currHealth);
    }
}
