using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BtnAttack : MonoBehaviour
{
    int weaponAtt = 10;
    int total;

    public Player player;
    public Enemy enemy;

    public void PlayerAttack()
    {
        if(Random.value < enemy.dodge)
        {
            Debug.Log("Attack missed");
        }
        else
        {
            double rnd = GetRandomNumber(50, 101);
            float power = (float)enemy.defense / (float)player.attack;
            //Debug.Log("Power is " + power);
            double percentDamage = Mathf.Pow(0.5f, power);
            //Debug.Log("Damage percent is " + percentDamage);
            int damage = player.attack + (int)(weaponAtt * rnd);
            total = (int)(damage * percentDamage);
            if (Random.value < player.critChance)
            {
                total = (int)(total * player.critDamage);
                Debug.Log("Player do critical attack deals " + total + "damage.");
            }
            else
            {
                Debug.Log("Player attack deals " + total + "damage.");
            }

            enemy.TakeDamage(total);
            Invoke("EnemyTurn", 1);
        }
        
    }

    void EnemyTurn()
    {
        if (Random.value < player.dodge)
        {
            Debug.Log("Player dodged enemy attacks.");
        }
        else
        {
            double rnd = GetRandomNumber(50, 101);
            float power = (float)player.defense / (float)enemy.attack;
            double percentDamage = Mathf.Pow(0.5f, power);
            //Debug.Log("Damage percent is " + percentDamage);
            int damage = (int)(enemy.attack * rnd);
            total = (int)(damage * percentDamage);
            if (Random.value < enemy.critChance)
            {
                total = (int)(total * player.critDamage);
                Debug.Log("Enemy do critical attack deals " + total + "damage.");
            }
            else
            {
                Debug.Log("Enemy attack deals " + total + "damage.");
            }
            player.TakeDamage(total);
        }
    }

    double GetRandomNumber(int min, int max)
    {
        double random = Random.Range(min, max);
        return random / 100;
    }
}
