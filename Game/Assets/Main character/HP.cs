using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HP : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    public HealthBar healthBar;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.setMaxHealth(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
            takeDamage(5);
        if(Input.GetKeyDown(KeyCode.P))
            incraseHp(10);
        if(Input.GetKeyDown(KeyCode.H))
            heal(5);
    }

    void takeDamage(int dmg){
        currentHealth -= dmg;
        healthBar.setHealth(currentHealth);
    }

    void incraseHp(int health){
        currentHealth += health;
        maxHealth += health;
        healthBar.changeMaxHealth(maxHealth, currentHealth);
        healthBar.addHealth(health);
    }

    void heal(int amt){
        if(currentHealth + amt > maxHealth)
            currentHealth = maxHealth;
        else
            currentHealth += amt;
        healthBar.setHealth(currentHealth);
    }
}
