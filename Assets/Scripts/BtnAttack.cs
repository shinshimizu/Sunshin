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


    public void OnClick()
    {
        if(Random.value < enemy.dodge)
        {
            Debug.Log("Attack missed");
        }
        else
        {
            double rnd = GetRandomNumber(50, 101);
            total = player.attack + (int)(weaponAtt * rnd);
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
            total = (int)(enemy.attack * rnd);
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

    public double GetRandomNumber(int min, int max)
    {
        double random = Random.Range(min, max);
        return random / 100;
    }
}
