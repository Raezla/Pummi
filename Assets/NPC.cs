﻿using UnityEngine;
using System.Collections;

public class NPC : IInteractiveObject
{
    private string name;
    private bool talked_to;

    public NPC(string name)
    {
        this.name = name;
        this.talked_to = false;
    }

    // IInteractiveObject interface methods
    public int Interact(int param)
    {
        Debug.Log("INTERACT!");
        talked_to = true;

        return 0;
    }

    public bool CanTalk()
    {
        return talked_to != true;
    }

    public bool CanLoot()
    {
        return false;
    }
}
