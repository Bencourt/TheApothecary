using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Potion
{
    public Potion[] similarPotions;
    public string name;
    public Item[] components = new Item[3];

    public Potion(string name, Item component1, Item component2, Item component3)
    {
        this.name = name;
        this.components[0] = component1;
        this.components[1] = component2;
        this.components[2] = component3;
    }

    public void setSimilar(Potion[] similarPotions)
    {
        this.similarPotions = similarPotions;
    }
}
