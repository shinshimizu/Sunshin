using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerModel : Element
{
    private int maxHealth;
    private int att;
    private int mag;
    private int def;
    private int res;
    private double critChance;
    private double critDamage;
    private double dodge;
    private int currHealth;
    private int playerId;

    public PlayerModel() { }

    public PlayerModel(int maxHealth, int att, int mag, int def, int res, double critChance, double critDamage, double dodge, int currHealth, int playerId)
    {
        this.maxHealth = maxHealth;
        this.att = att;
        this.mag = mag;
        this.def = def;
        this.res = res;
        this.critChance = critChance;
        this.critDamage = critDamage;
        this.dodge = dodge;
        this.currHealth = currHealth;
        this.playerId = playerId;
    }

    public int GetMaxHealth()
    {
        return maxHealth;
    }
    public void SetMaxHealth(int maxHealth)
    {
        this.maxHealth = maxHealth;
    }

    public int GetAtt()
    {
        return att;
    }
    public void SetAtt(int att)
    {
        this.att = att;
    }

    public int GetMag()
    {
        return mag;
    }
    public void SetMag(int mag)
    {
        this.mag = mag;
    }

    public int GetDef()
    {
        return def;
    }
    public void SetDef(int def)
    {
        this.def = def;
    }

    public int GetRes()
    {
        return res;
    }
    public void SetRes(int res)
    {
        this.res = res;
    }

    public double GetCritChance()
    {
        return critChance;
    }
    public void SetCritChance(double critChance)
    {
        this.critChance = critChance;
    }

    public double GetCritDamage()
    {
        return critDamage;
    }
    public void SetCritDamage(double critDamage)
    {
        this.critDamage = critDamage;
    }

    public double GetDodge()
    {
        return dodge;
    }
    public void SetDodge(double dodge)
    {
        this.dodge = dodge;
    }

    public int GetCurrHealth()
    {
        return currHealth;
    }
    public void SetCurrHealth(int currHealth)
    {
        this.currHealth = currHealth;
    }

    public int GetPlayerId()
    {
        return playerId;
    }
    public void SetPlayerId(int playerId)
    {
        this.playerId = playerId;
    }
}
