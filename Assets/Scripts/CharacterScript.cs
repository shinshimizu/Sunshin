using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterScript : MonoBehaviour
{
    public HealthBar healthBar;
    public NotifboardScript notifBoard;

    public int maxHealth;
    public int currentHealth;
    public int maxEnergy;
    public int currentEnergy;
    public int attack;
    public int magic;
    public int defense;
    public int resistance;
    public int aim;
    public int evasion;
    public double critChance;
    public double critDamage;

    public void SetStats(int maxHealth, int maxEnergy, int attack, int magic, int defense, int resistance,
                         int aim, int evasion, double critChance, double critDamage)
    {
        currentHealth = this.maxHealth = maxHealth;
        currentEnergy = this.maxEnergy = maxEnergy;
        this.attack = attack;
        this.magic = magic;
        this.defense = defense;
        this.resistance = resistance;
        this.aim = aim;
        this.evasion = evasion;
        this.critChance = critChance;
        this.critDamage = critDamage;

        healthBar.SetMaxHealth(maxHealth);
        healthBar.SetMaxEnergy(maxEnergy);
    }

    public void EnergyUpdate(int cost)
    {
        currentEnergy += cost;
        healthBar.SetEnergy(currentEnergy);
    }

    public void TakeDamage(int damage)
    {      
        if(currentHealth > damage)
        {
            currentHealth -= damage;
            healthBar.SetHealth(currentHealth);
            currentEnergy -= 10;
            healthBar.SetEnergy(currentEnergy);
        }
        else
        {
            currentHealth = 0;
            healthBar.SetHealth(currentHealth);
            notifBoard.CheckBattle();
        }
    }
}
