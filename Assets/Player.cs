﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Player
{
    private double cash;
    private int location;
    private Vector2 position;
    private bool es_buff;

    public Player()
    {
        cash = 0;
        position = new Vector2(400, 100);
        es_buff = false;
    }

    public void AddCash(double amount)
    {
        cash += amount;
        if (cash < 0.0)
            cash = 0.0;
    }

    public double GetCash()
    {
        return cash;
    }

    public void SetLocation(int new_location)
    {
        location = new_location;
    }

    public int GetLocation()
    {
        return location;
    }

    public void SetPosition(Vector2 pos)
    {
        position = pos;
    }

    public Vector2 GetPosition()
    {
        return position;
    }

    public void SetESBuff()
    {
        es_buff = true;
    }

    public bool HasESBuff()
    {
        return es_buff;
    }
}
