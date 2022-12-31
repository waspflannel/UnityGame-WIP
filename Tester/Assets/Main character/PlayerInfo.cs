using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInfo : MonoBehaviour
{
    
    public int maxHealth = 100;
    public int currentHealth;
    public HealthBar healthBar;

    public int maxMana = 20;
    public int currentMana;
    public ManaBar manaBar;

    public float maxEnergy = 20;
    public float currentEnergy;
    public EnergyBar energyBar;

    public bool vulnerable = true;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.setMaxHealth(maxHealth);

        currentMana = maxMana;
        manaBar.setMaxMana(maxMana);

        currentEnergy = maxEnergy;
        energyBar.setMaxEnergy(maxEnergy);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.I))
            takeDamage(5);
        if(Input.GetKeyDown(KeyCode.P))
            incraseHp(10);
        if(Input.GetKeyDown(KeyCode.O))
            heal(5);

        if(Input.GetKeyDown(KeyCode.L))
            useMana(1);
        if(Input.GetKeyDown(KeyCode.K))
            incraseMana(2);
        if(Input.GetKeyDown(KeyCode.J))
            restoreMana(2);

        restoreEnergy(0.01f);
        if(Input.GetMouseButtonDown(0))
            useEnergy(10f);
        if(Input.GetMouseButtonDown(1))
            increaseEnergy(5f);
    }

    void takeDamage(int dmg){
        if(vulnerable){
            currentHealth -= dmg;
            healthBar.setHealth(currentHealth);
            healthBar.flash();
        }
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


    void useMana(int mana){
        currentMana -= mana;
        manaBar.setMana(currentMana);
    }

    void incraseMana(int mana){
        currentMana += mana;
        maxMana += mana;
        manaBar.changeMaxMana(maxMana, currentMana);
        manaBar.addMana(mana);
    }

    void restoreMana(int amt){
        if(currentMana + amt > maxMana)
            currentMana = maxMana;
        else
            currentMana += amt;
        manaBar.setMana(currentMana);
    }

    void useEnergy(float energy){
        currentEnergy -= energy;
        energyBar.setEnergy(currentEnergy);
    }

    void restoreEnergy(float amt){
        if(currentEnergy + amt > maxEnergy)
            currentEnergy = maxEnergy;
        else
            currentEnergy += amt;
        energyBar.setEnergy(currentEnergy);
    }

    void increaseEnergy(float energy){
        currentEnergy += energy;
        maxEnergy += energy;
        energyBar.changeMaxEnergy(maxEnergy, currentEnergy);
        energyBar.addEnergy(energy);
    }
}
