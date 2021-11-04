using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalBear : MonoBehaviour
{
    CharacterScript stat;

    // Start is called before the first frame update
    void Start()
    {
        stat = GetComponentInParent<CharacterScript>();

        stat.MaxHealth = 200;
        stat.MaxEnergy = 100;
        stat.Attack = 10;
        stat.Magic = 0;
        stat.Defense = 5;
        stat.Resistance = 5;
        stat.Accuracy = 1;
        stat.Evasion = 1;

        stat.CurrHealth = 200;
        stat.CurrEnergy = 100;
        stat.CritChance = 0.05;
        stat.CritDamage = 1.5;
    }

    public void EnemyAttack()
    {
        /*
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
                enemy.statuses.SetAttbuff(1.5, 0);
                enemy.Action(0, 2);
                break;
            default:
                print("Enemy uses basic attack");
                StartCoroutine(AttackHandler(enemy, player, enemy.attack, player.defense, 1, (success) => { }));
                break;
        }
        */
    }

    double GetRandomNumber(int min, int max)
    {
        double random = Random.Range(min, max);
        return random / 100;
    }
}
