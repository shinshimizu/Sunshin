using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterBase : MonoBehaviour
{
    private int hp;
    private int cHp;
    private int ep;
    private int cEp;
    private int atk;
    private int mag;
    private int def;
    private int res;
    private int aim;
    private int dex;

    public void SetStats(int hp, int ep, int atk, int mag, int def, int res, int aim, int dex)
    {
        Hp = CHp = hp;
        Ep = CEp = ep;
        Atk = atk;
        Mag = mag;
        Def = def;
        Res = res;
        Aim = aim;
        Dex = dex;
    }

    public bool IsDead()
    {
        if (CHp <= 0)
            return true;
        return false;
    }

    public int Hp { get; set; }
    public int CHp { get; set; }
    public int Ep { get; set; }
    public int CEp { get; set; }
    public int Atk { get; set; }
    public int Mag { get; set; }
    public int Def { get; set; }
    public int Res { get; set; }
    public int Aim { get; set; }
    public int Dex { get; set; }

    public void AlterHp(int num, Action OnAltered)
    {
        CHp += num;
        CHp = CHp > Hp ? Hp : CHp;
        CHp = CHp < 0 ? 0 : CHp;
        OnAltered();
    }

    public void AlterEp(int num, Action OnAltered)
    {
        CEp += num;
        CEp = CEp > Ep ? Ep : CEp;
        CEp = CEp < 0 ? 0 : CEp;
        OnAltered();
    }

    // Animation Methods are written here

    private void Awake()
    {
    }

    public void GetSprite(Sprite sprite)
    {
        transform.Find("Body").GetComponent<SpriteRenderer>().sprite = sprite;
    }
}
