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
    public double attack;
    public double magic;
    public double defense;
    public double resistance;
    public double aim;
    public double evasion;
    public double critChance;
    public double critDamage;

    public void SetStats(int maxHealth, int maxEnergy, double attack, double magic, double defense, double resistance,
                         double aim, double evasion, double critChance, double critDamage)
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

        statuses.SetStatuses(false, 0, 1, 0);
    }

    public void Action(int health, int energy)
    {
        CheckHealthBar(health);
        CheckEnergyBar(energy);
        if (currentHealth == 0)
        {
            notifBoard.CheckBattle();
        }
    }

    void CheckHealthBar(int health)
    {
        if (currentHealth > maxHealth)
            currentEnergy = maxHealth;
        else if (currentHealth < 0)
            currentHealth = 0;
        else
            currentHealth += health;

        healthBar.SetHealth(currentHealth);
    }

    void CheckEnergyBar(int energy)
    {
        if (currentEnergy > maxEnergy)
            currentEnergy = maxEnergy;
        else if (currentEnergy < 0)
            currentEnergy = 0;
        else
            currentEnergy += energy;

        healthBar.SetEnergy(currentEnergy);
    }

    public void CheckStats(ref StatusesScript s)
    {
        if (s.airborneTurn > 0)
        {
            Action(-s.AirborneUpdate(), 0);
            if (!s.isAirborne)
                s.airborne = 0;
        }

        if (!s.AttbuffUpdate())
        {
            attack /= s.attbuff;
            s.attbuff = 1;
        }
        if (!s.DefbuffUpdate())
        {
            defense /= s.defbuff;
            s.defbuff = 1;
        }
        if (!s.AttdebUpdate())
        {
            attack *= s.attdeb;
            s.attdeb = 1;
        }
        if (!s.DefdebUpdate())
        {
            defense *= s.defdeb;
            s.defdeb = 1;
        }
    }
}
