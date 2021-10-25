using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BtnAttack : MonoBehaviour
{
    int weaponAtt = 10;
    int baseDmg = 2;
    int total;

    public Enemy enemyHealth;
    public HealthBar enemyHealthBar;


    public void OnClick()
    {
        double rnd = GetRandomNumber(50, 100);
        total = baseDmg + (int)(weaponAtt * rnd);
        enemyHealth.TakeDamage(total);
    }

    public double GetRandomNumber(int min, int max)
    {
        double random = Random.Range(min, max);
        return random / 100;
    }
}
