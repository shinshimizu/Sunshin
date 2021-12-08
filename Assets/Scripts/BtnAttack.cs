using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BtnAttack : MonoBehaviour
{
    int weaponAtt = 10;
    int spellA = 10;
    int spellB = 20;
    int total;

    public CharacterScript player;
    public CharacterScript enemy;
    public Button[] buttons = new Button[4];
    
    void Start()
    {
        player.statuses = gameObject.AddComponent<StatusesScript>();
        enemy.statuses = gameObject.AddComponent<StatusesScript>();
        player.SetStats(100, 100, 2, 1, 2, 1, 1, 2, 0.05, 1.5);
        enemy.SetStats(100, 100, 10, 0, 5, 2, 1, 1, 0.05, 1.5);
    }

    public void PlayerAttack()
    {
        print("Player uses basic attack");
        StartCoroutine(AttackHandler(player, enemy, player.attack, enemy.defense, weaponAtt, (success) => { }));
        player.CheckStats(ref player.statuses);
        StartCoroutine(EnemyTurn());
    }

    public void PlayerSkill1()
    {
        print("Player uses skill attack and debuff enemy attack for 1 turn");
        player.Action(0, -5);        
        StartCoroutine(AttackHandler(player, enemy, player.magic, enemy.resistance, spellA, (success) =>
        {
            if (success)
            {
                if (!enemy.statuses.isAttdeb)
                    enemy.attack /= 1.5;
                enemy.statuses.SetAttdeb(1.5, 1);
                print("Enemy att reduced to " + enemy.attack);
            }
        }));
        player.CheckStats(ref player.statuses);
        StartCoroutine(EnemyTurn());
    }

    public void PlayerSkill2()
    {
        print("Player uses wind attack and airborne enemy for 1 turn");
        player.Action(0, -10);
        StartCoroutine(AttackHandler(player, enemy, player.magic, enemy.resistance, spellB, (success) => 
        {
            if (success) 
            {
                print("Attack success, applying status effect");
                enemy.statuses.SetAirborne(5, 1);
            }
        }));
        player.CheckStats(ref player.statuses);
        StartCoroutine(EnemyTurn());
    }

    public void PlayerSkill3()
    {
        print("Player uses energy recovery skill and increasing defend for 1 turn");
        player.Action(0, 15);
        if (!player.statuses.isDefbuff)
            player.defense = player.defense * 1.5;
        player.statuses.SetDefbuff(1.5, 1);
        player.CheckStats(ref player.statuses);
        StartCoroutine(EnemyTurn());
    }

    IEnumerator AttackHandler(CharacterScript attacker, CharacterScript defender, double attackType, double defendType, int skill, System.Action<bool> action)
    {
        double dodge = 0.05;
        if (defender.evasion > attacker.aim) // calculate dodge
        {
            dodge = 0.05 * 2 * defender.evasion / attacker.aim;
        }

        if (Random.value > dodge || defender.currentEnergy < 10) // attack successful
        {
            float power = (float)defendType / (float)attackType;
            double percentDamage = Mathf.Pow(0.5f, power); // calculate damage reduction
            int damage = (int)((attackType * GetRandomNumber(75, 101)) + (skill * GetRandomNumber(50, 101))); // randomized damage
            total = (int)(damage * percentDamage);

            if (Random.value < attacker.critChance) // calculate crit damage
            {
                total = (int)(total * attacker.critDamage);
                print("Deal " + total + " critical damage!");
            }
            else
            {
                print("Deal " + total + " damage.");
            }

            defender.Action(-total, -10);
            action(true);
        }
        else // dodge successful
        {
            print("Attack missed");
            action(false);
        }
        yield return null;
    }

    void PlayerTurn()
    {
        if (enemy.currentHealth > 0 && player.currentHealth > 0)
        {
            ButtonsInteraction(true);
        }
        player.Action(0, 2);
    }

    IEnumerator EnemyTurn()
    {
        ButtonsInteraction(false);
        enemy.Action(0, 2);
        print("Enemy att is " + enemy.attack);

        switch ((int)(GetRandomNumber(1, 6) * 100))
        {
            case 4:
                print("Enemy is defending for 1 turn");
                if (!enemy.statuses.isDefbuff)
                    enemy.defense *= 1.5;
                enemy.statuses.SetDefbuff(1.5, 1);
                enemy.Action(0, 5);
                break;
            case 5:
                print("Enemy is raging for 1 turn");
                if (!enemy.statuses.isAttbuff)
                    enemy.attack *= 1.5;
                enemy.statuses.SetAttbuff(1.5, 1);
                enemy.Action(0, 2);
                print("Enemy atk is raised to " + enemy.attack);
                break;
            default:
                print("Enemy uses basic attack");
                StartCoroutine(AttackHandler(enemy, player, enemy.attack, player.defense, 1, (success) => { }));
                break;
        }

        yield return new WaitForSeconds(1f);
        enemy.CheckStats(ref enemy.statuses);
        print("Enemy att returned to " + enemy.attack);
        PlayerTurn();
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
