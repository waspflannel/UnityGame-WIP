using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Tilemaps;
using UnityEngine.InputSystem;

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

    public int vulnerable = 0;

    public GameObject [] spikes;

    public Texture2D cursor;
    public Movement movement;

    public int maxDashCD = 50;
    private int dashCD = 0;

    void Start()
    {
        Cursor.SetCursor(cursor, Vector2.zero, CursorMode.ForceSoftware);
        initializeStats();
    }

    void Update()
    {
        checkInputs();
    }

    void FixedUpdate()
    {
        restoreEnergy(0.1f);
        restoreDash();
        restoreVulnerable();
    }

    public void takeDamage(int dmg)
    {
        if(vulnerable == 0)
        {
            currentHealth -= dmg;
            healthBar.setHealth(currentHealth);
            healthBar.flash();
        }
    }

    void incraseHp(int health)
    {
        currentHealth += health;
        maxHealth += health;
        healthBar.changeMaxHealth(maxHealth, currentHealth);
        healthBar.addHealth(health);
    }

    void heal(int amt)
    {
        if(currentHealth + amt > maxHealth)
            currentHealth = maxHealth;
        else
            currentHealth += amt;
        healthBar.setHealth(currentHealth);
    }


    void useMana(int mana)
    {
        currentMana -= mana;
        manaBar.setMana(currentMana);
    }

    void incraseMana(int mana)
    {
        currentMana += mana;
        maxMana += mana;
        manaBar.changeMaxMana(maxMana, currentMana);
        manaBar.addMana(mana);
    }

    void restoreMana(int amt)
    {
        if(currentMana + amt > maxMana)
            currentMana = maxMana;
        else
            currentMana += amt;
        manaBar.setMana(currentMana);
    }

    void useEnergy(float energy)
    {
        currentEnergy -= energy;
        energyBar.setEnergy(currentEnergy);
    }

    void restoreEnergy(float amt)
    {
        if(currentEnergy + amt > maxEnergy)
            currentEnergy = maxEnergy;
        else
            currentEnergy += amt;
        energyBar.setEnergy(currentEnergy);
    }

    void increaseEnergy(float energy)
    {
        currentEnergy += energy;
        maxEnergy += energy;
        energyBar.changeMaxEnergy(maxEnergy, currentEnergy);
        energyBar.addEnergy(energy);
    }


    public void CheckSpikes()
    {
        foreach (GameObject spike in spikes)
        {
            if(spike.transform.GetComponent<Spikes>().isOpen)
            {
                takeDamage(5);
                return;
            }
        }
    }

    public bool isVulnerable()
    {
        return vulnerable == 0;
    }

    public bool canDash()
    {
        return dashCD == 0;
    }

    private void restoreDash()
    {
        if(!canDash())
        {
            dashCD--;
        }
    }

    private void restoreVulnerable()
    {
        if(!isVulnerable())
        {
            vulnerable--;
        }
        else
        {
            damageCheck();
        }
    }

    private void damageCheck()
    {
        CheckSpikes();
    }

    private void checkInputs()
    {
        /*if(Input.GetKeyDown(KeyCode.I))
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
        if(Input.GetMouseButtonDown(2))
            increaseEnergy(5f);*/
    }

    public void dashMove(InputAction.CallbackContext context)
    {
            if(context.performed && canDash() && currentEnergy >= 10f)
            {
                movement.dashMove();
                useEnergy(10f);
                dashCD = maxDashCD;
                vulnerable = 8;
            }
    }

    private void initializeStats()
    {
        currentHealth = maxHealth;
        healthBar.setMaxHealth(maxHealth);

        currentMana = maxMana;
        manaBar.setMaxMana(maxMana);

        currentEnergy = maxEnergy;
        energyBar.setMaxEnergy(maxEnergy);
    }
}