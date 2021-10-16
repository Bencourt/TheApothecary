using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemList : MonoBehaviour
{
    public static Item[] itemCatalog;
    // Start is called before the first frame update
    void Awake()
    {
        itemCatalog = new Item[10];
        itemCatalog[0] = new Item();
        itemCatalog[1] = new Item("Chamomile", 15, 1, "A daisy-like flower used to make herbal infusions");
        itemCatalog[2] = new Item("Lavender", 15, 1, "A beautiful purple flower with a strong scent");
        itemCatalog[3] = new Item("Basil", 20, 2, "A flavorful herb with smooth shiny leaves");
        itemCatalog[4] = new Item("Sage", 20, 2, "A savory herb said to cleanse negative energy when burned");
        itemCatalog[5] = new Item("Rosemary", 20, 3, "A fragrant herb with long thin green leaves");
        itemCatalog[6] = new Item("Mint", 20, 3, "A cool flavored herb with soft jagged leaves");
        itemCatalog[7] = new Item("Cloves", 35, 5, "A flowering tree whose buds can be dried into spices");
        itemCatalog[8] = new Item("Oranges", 50, 5, "A citrus tree with sweet fruits");
        itemCatalog[9] = new Item("Corn", 60, 4, "A tall vegetable plant yeilding sweet cobs of corn");
    }
}
