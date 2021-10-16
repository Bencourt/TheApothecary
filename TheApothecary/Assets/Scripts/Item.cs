using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item
{
    private string name;
    private int cost;
    private int time;
    private string description;

    public int Time
    {
        get { return time; }
        set { time = value; }
    }

    public string Name
    {
        get { return name; }
        set { name = value;  }
    }

    public int Cost
    {
        get { return cost; }
        set { cost = value; }
    }

    public string Description
    {
        get { return description; }
        set { description = value; }
    }

    public Item()
    {
        name = "Rose";
        cost = 10;
        time = 1;
        description = "A basic rose";
    }

    public Item(string name, int cost, int time, string desc)
    {
        this.name = name;
        this.cost = cost;
        this.time = time;
        this.description = desc;
    }
}
