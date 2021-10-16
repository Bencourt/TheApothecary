using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotionList : MonoBehaviour
{
    public List<Potion> potionCatalog;

    public Item[] itemCatalog;

    // Start is called before the first frame update
    void Start()
    {
        itemCatalog = ItemList.itemCatalog;
        potionCatalog = new List<Potion>();

        potionCatalog.Add(new Potion("Protection", itemCatalog[0], itemCatalog[0], itemCatalog[0]));
        potionCatalog.Add(new Potion("Productivity", itemCatalog[1], itemCatalog[1], itemCatalog[1]));
        potionCatalog.Add(new Potion("Healing", itemCatalog[2], itemCatalog[2], itemCatalog[2]));
        potionCatalog.Add(new Potion("Relaxation", itemCatalog[3], itemCatalog[3], itemCatalog[3]));
        potionCatalog.Add(new Potion("Communication", itemCatalog[4], itemCatalog[4], itemCatalog[4]));
        potionCatalog.Add(new Potion("Voodoo", itemCatalog[9], itemCatalog[9], itemCatalog[9]));
        potionCatalog.Add(new Potion("Sleep", itemCatalog[6], itemCatalog[6], itemCatalog[6]));
        potionCatalog.Add(new Potion("Thieve's Vinegar", itemCatalog[7], itemCatalog[7], itemCatalog[7]));
        potionCatalog.Add(new Potion("Harming", itemCatalog[8], itemCatalog[8], itemCatalog[8]));


        potionCatalog[0].setSimilar(new Potion[2] { potionCatalog[2], potionCatalog[3]});
        potionCatalog[1].setSimilar(new Potion[3] { potionCatalog[3], potionCatalog[4], potionCatalog[7] });
        potionCatalog[2].setSimilar(new Potion[3] { potionCatalog[0], potionCatalog[3], potionCatalog[6]});
        potionCatalog[3].setSimilar(new Potion[2] { potionCatalog[6], potionCatalog[5]});
        potionCatalog[4].setSimilar(new Potion[2] { potionCatalog[1], potionCatalog[5]});
        potionCatalog[5].setSimilar(new Potion[3] { potionCatalog[8], potionCatalog[6], potionCatalog[4] });
        potionCatalog[6].setSimilar(new Potion[3] { potionCatalog[5], potionCatalog[3], potionCatalog[0] });
        potionCatalog[7].setSimilar(new Potion[2] { potionCatalog[1], potionCatalog[0] });
        potionCatalog[8].setSimilar(new Potion[2] { potionCatalog[6], potionCatalog[5]});
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
