using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterScript : MonoBehaviour
{
    public HealthBar healthBar;
    public NotifboardScript notifBoard;
    public StatusesScript statuses;

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
        CheckEnergyBar();
        healthBar.SetEnergy(currentEnergy);
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        CheckHealthBar();
        healthBar.SetHealth(currentHealth);
        currentEnergy -= 10;
        CheckEnergyBar();
        healthBar.SetEnergy(currentEnergy);
        if (currentHealth < damage)
        {
            notifBoard.CheckBattle();
        }
    }

    void CheckHealthBar()
    {
        if (currentHealth > maxHealth)
            currentEnergy = maxHealth;
        if (currentHealth < 0)
            currentHealth = 0;
    }

    void CheckEnergyBar()
    {
        if (currentEnergy > maxEnergy)
            currentEnergy = maxEnergy;
        if (currentEnergy < 0)
            currentEnergy = 0;
    }

    public void CheckStats()
    {
        TakeDamage(statuses.AirborneUpdate());

        if (!statuses.AttbuffUpdate())
        {
            attack -= statuses.attbuff;
            statuses.attbuff = 0;
        }
        if (!statuses.DefbuffUpdate())
        {
            defense -= statuses.defbuff;
            statuses.defbuff = 0;
        }
        if (!statuses.AttdebUpdate())
        {
            attack += statuses.attdeb;
            statuses.attdeb = 0;
        }
        if (!statuses.DefdebUpdate())
        {
            defense += statuses.defdeb;
            statuses.defdeb = 0;
        }
    }
}
