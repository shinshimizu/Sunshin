using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatusesScript : MonoBehaviour
{
    public bool isAirborne;
    public int airborneTurn;
    public int airborne;

    public bool isAttbuff;
    public int attbuffTurn;
    public int attbuff;

    public bool isDefbuff;
    public int defbuffTurn;
    public int defbuff;

    public bool isAttdeb;
    public int attdebTurn;
    public int attdeb;

    public bool isDefdeb;
    public int defdebTurn;
    public int defdeb;

    private void Start()
    {
        isAirborne = false;
        airborneTurn = 0;
        airborne = 0;

        isAttbuff = false;
        attbuffTurn = 0;
        attbuff = 0;

        isDefbuff = false;
        defbuffTurn = 0;
        defbuff = 0;

        isAttdeb = false;
        attdebTurn = 0;
        attdeb = 0;

        isDefdeb = false;
        defdebTurn = 0;
        defdeb = 0;
    }

    public void SetAirborne(int val, int turn)
    {
        isAirborne = true;
        airborneTurn = turn;
        airborne = val;
    }

    public void SetAttbuff(int val, int turn)
    {
        isAttbuff = true;
        attbuffTurn = turn;
        attbuff = val;
    }

    public void SetDefbuff(int val, int turn)
    {
        isDefbuff = true;
        defbuffTurn = turn;
        defbuff = val;
    }

    public void SetAttdeb(int val, int turn)
    {
        isAttdeb = true;
        attdebTurn = turn;
        attdeb = val;
    }

    public void SetDefdeb(int val, int turn)
    {
        isDefdeb = true;
        defdebTurn = turn;
        defdeb = val;
    }

    public int AirborneUpdate()
    {
        if (airborneTurn > 0)
        {
            airborneTurn--;
        }
        else
        {
            isAirborne = false;
            airborne = 0;
        }
        return airborne;
    }

    public bool AttbuffUpdate()
    {
        if (attbuffTurn > 0)
        {
            attbuffTurn -= 1;
        }
        else
        {
            isAttbuff = false;
        }
        return isAttbuff;
    }

    public bool DefbuffUpdate()
    {
        if (defbuffTurn > 0)
        {
            defbuffTurn -= 1;
        }
        else
        {
            isDefbuff = false;
        }
        return isDefbuff;
    }

    public bool AttdebUpdate()
    {
        if (attdebTurn > 0)
        {
            attdebTurn -= 1;
        }
        else
        {
            isAttdeb = false;
        }
        return isAttdeb;
    }

    public bool DefdebUpdate()
    {
        if (defdebTurn > 0)
        {
            defdebTurn -= 1;
        }
        else
        {
            isDefdeb = false;
        }
        return isDefdeb;
    }
}
