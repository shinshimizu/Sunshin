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
    public double attbuff;

    public bool isDefbuff;
    public int defbuffTurn;
    public double defbuff;

    public bool isAttdeb;
    public int attdebTurn;
    public double attdeb;

    public bool isDefdeb;
    public int defdebTurn;
    public double defdeb;

    public void SetStatuses(bool b, int status, double db, int turn)
    {
        isAirborne = b;
        airborneTurn = turn;
        airborne = status;

        isAttbuff = b;
        attbuffTurn = turn;
        attbuff = db;

        isDefbuff = b;
        defbuffTurn = turn;
        defbuff = db;

        isAttdeb = b;
        attdebTurn = turn;
        attdeb = db;

        isDefdeb = b;
        defdebTurn = turn;
        defdeb = db;
    }

    public void SetAirborne(int val, int turn)
    {
        isAirborne = true;
        airborneTurn = turn;
        airborne = val;
    }

    public void SetAttbuff(double val, int turn)
    {
        isAttbuff = true;
        attbuffTurn = turn;
        attbuff = val;
    }

    public void SetDefbuff(double val, int turn)
    {
        isDefbuff = true;
        defbuffTurn = turn - 1;
        defbuff = val;
    }

    public void SetAttdeb(double val, int turn)
    {
        isAttdeb = true;
        attdebTurn = turn;
        attdeb = val;
    }

    public void SetDefdeb(double val, int turn)
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
        if (airborneTurn == 0)
        {
            isAirborne = false;
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
