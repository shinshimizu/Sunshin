using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BtnAttack : MonoBehaviour
{
    int hp = 100;
    int weaponAtt = 10;
    int baseDmg = 2;
    int total;
    public Text enemyHp = null;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void OnClick()
    {
        double rnd = GetRandomNumber(50, 100);
        total = baseDmg + (int)(weaponAtt * rnd);
        hp = hp - total;
        UpdateHP(hp);
        Debug.Log("Deals " + total + "damage! Enemy has "+ hp +" HP left.");
    }

    public double GetRandomNumber(int min, int max)
    {
        double random = Random.Range(min, max);
        return random / 100;
    }

        public void UpdateHP(int hp)
    {
        enemyHp.text = "HP :" + hp.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
