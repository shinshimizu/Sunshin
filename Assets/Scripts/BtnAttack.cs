using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BtnAttack : MonoBehaviour
{
    int weaponAtt = 10;
    int spellA = 10;
    int spellB = 20;
    int spellC = 2;
    //int[] condiDamage;
    //int[] condiTurn;
    int total;
    bool turn;

    public CharacterScript player;
    public CharacterScript enemy;
    public Button[] buttons = new Button[4];

    void Start()
    {
        player.SetStats(100, 100, 2, 1, 2, 1, 1, 2, 0.05, 1.5);
        enemy.SetStats(100, 100, 10, 0, 5, 2, 1, 1, 0.05, 1.5);
    }

    public void PlayerAttack()
    {
        turn = true;
        StartCoroutine(AttackHandler(player, enemy, player.attack, enemy.defense, weaponAtt, 0));
    }

    public void PlayerSkill1()
    {
        turn = true;
        StartCoroutine(AttackHandler(player, enemy, player.magic, enemy.resistance, spellA, 0));
    }

    public void PlayerSkill2()
    {
        turn = true;
        //condiDamage[2] = 5;
        //condiTurn[2] = 3;
        player.EnergyUpdate(-10);
        StartCoroutine(AttackHandler(player, enemy, player.magic, enemy.resistance, spellB, 0));
    }

    public void PlayerSkill3()
    {
        turn = true;
        player.EnergyUpdate(25);
        StartCoroutine(AttackHandler(player, enemy, player.magic, enemy.resistance, spellC, 0));
    }

    IEnumerator AttackHandler(CharacterScript attacker, CharacterScript defender, int attackType, int defendType, int skill, int delay)
    {
        yield return new WaitForSeconds(delay);

        ButtonsInteraction(false);

        double dodge = 0.05;
        if (defender.evasion > attacker.aim) // calculate dodge
        {
            dodge = 0.05 * 2 * defender.evasion / attacker.aim;
        }

        if (Random.value > dodge || defender.currentEnergy == 0) // attack successful
        {
            double rnd1 = GetRandomNumber(75, 101);
            double rnd2 = GetRandomNumber(50, 101);
            float power = (float)defendType / (float)attackType;
            double percentDamage = Mathf.Pow(0.5f, power);
            int damage = (int)((attackType * rnd1) + (skill * rnd2));
            total = (int)(damage * percentDamage);

            if (Random.value < attacker.critChance) // calculate crit damage
            {
                total = (int)(total * attacker.critDamage);
                Debug.Log(total + "critical damage!");
            }
            else
            {
                Debug.Log(total + "damage.");
            }

            defender.TakeDamage(total);               
        }
        else // dodge successful
        {
            Debug.Log("Attack missed");
        }

        if (defender.currentHealth > 0 && !turn)
        {
            ButtonsInteraction(true);
        }

        if (turn) // enemy turn
        {
            turn = false;
            StartCoroutine(AttackHandler(enemy, player, enemy.attack, player.defense, 1, 1));            
        }
    }

    void ButtonsInteraction(bool interaction)
    {
        foreach (Button b in buttons)
        {
            b.interactable = interaction;
        }
    }

    double GetRandomNumber(int min, int max)
    {
        double random = Random.Range(min, max);
        return random / 100;
    }
}
