using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Customer
{

    private string name;
    private string description;
    private string requestText;
    private Potion bestItem;
    private int offer;

    public string Name
    {
        get { return name; }
        set { name = value; }
    }
    public string Description
    {
        get { return description; }
        set { description = value; }
    }
    public string RequestText
    {
        get { return requestText; }
        set { requestText = value; }
    }
    public int Offer
    {
        get { return offer; }
        set { offer = value; }
    }
    public Potion BestItem
    {
        get { return bestItem; }
        set { bestItem = value; }
    }

    public Customer()
    {
        name = "default name";
        description = "default character description";
        requestText = "Please give me a boring, default potion";
        offer = 30;
        bestItem = GameObject.Find("GameManager").GetComponent<PotionList>().potionCatalog[0];
    }

    public Customer(string name, string description, string requestText, int offer, Potion bestItem)
    {
        this.name = name;
        this.description = description;
        this.requestText = requestText;
        this.offer = offer;
        this.bestItem = bestItem;
    }

}
