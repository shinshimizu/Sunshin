using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BtnAttack : MonoBehaviour
{
    int weaponAtt = 10;
    int spellA = 10;
    int spellB = 20;
    //int[] condiDamage;
    //int[] condiTurn;
    int total;
    bool turn;
    bool statusAttack;

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
        print("Player uses basic attack");
        StartCoroutine(AttackHandler(player, enemy, player.attack, enemy.defense, weaponAtt, 0));
    }

    public void PlayerSkill1()
    {
        turn = true;
        print("Player uses skill attack and debuff enemy attack for 1 turn");
        StartCoroutine(AttackHandler(player, enemy, player.magic, enemy.resistance, spellA, 0));
    }

    public void PlayerSkill2()
    {
        turn = true;
        player.EnergyUpdate(-10);
        statusAttack = true;
        print("Player uses wind attack and airborne enemy for 1 turn");
        StartCoroutine(AttackHandler(player, enemy, player.magic, enemy.resistance, spellB, 0));
    }

    public void PlayerSkill3()
    {
        turn = true;
        player.EnergyUpdate(25);
        int x = (int)(player.defense * 1.5) - player.defense;
        if (!player.statuses.isDefbuff)
        {
            player.defense = (int)(player.defense * 1.5);
        }
        player.statuses.SetDefbuff(x, 2);
        print("Player uses energy recovery skill and increasing defend for 2 turn");
        EnemyTurn();
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
            float power = (float)defendType / (float)attackType;
            double percentDamage = Mathf.Pow(0.5f, power);
            int damage = (int)((attackType * GetRandomNumber(75, 101)) + (skill * GetRandomNumber(50, 101)));
            total = (int)(damage * percentDamage);

            if (Random.value < attacker.critChance) // calculate crit damage
            {
                total = (int)(total * attacker.critDamage);
                print(total + " critical damage!");
            }
            else
            {
                print(total + " damage.");
            }

            defender.TakeDamage(total);
            
            if (statusAttack) // applying status effect
            {

            }
        }
        else // dodge successful
        {
            print("Attack missed");
        }

        if (turn) // enemy turn
        {
            turn = false;
            EnemyTurn();                        
        }
        else
        {
            PlayerTurn();
        }
    }

    void PlayerTurn()
    {
        player.CheckStats();
        if (enemy.currentEnergy > 0 && player.currentHealth > 0)
        {
            ButtonsInteraction(true);
        }
    }

    void EnemyTurn()
    {
        enemy.CheckStats();

        switch ((int)(GetRandomNumber(1, 4) * 100))
        {
            case 1:
                print("Enemy uses basic attack");
                StartCoroutine(AttackHandler(enemy, player, enemy.attack, player.defense, 1, 1));
                break;
            case 2:
                print("Enemy is defending for 1 turn");
                enemy.defense += 2;
                enemy.statuses.SetDefbuff(2, 1);
                PlayerTurn();
                break;
            case 3:
                print("Enemy is raging for 1 turn");
                enemy.attack += 2;
                enemy.statuses.SetAttbuff(2, 1);
                PlayerTurn();
                break;
        }
    }

    void ButtonsInteraction(bool interaction)
    {
        foreach (Button b in buttons)
        {
            b.interactable = interaction;
        }

        if (player.currentEnergy < 10)
        {
            buttons[2].interactable = false;
        }
    }

    double GetRandomNumber(int min, int max)
    {
        double random = Random.Range(min, max);
        return random / 100;
    }
}
