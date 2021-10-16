using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Crafting : MonoBehaviour
{
    public Button[] Components;
    private List<Potion> potionList;

    public Text componentText1;
    public Text componentText2;
    public Text componentText3;

    private Item componentItem1;
    private Item componentItem2;
    private Item componentItem3;

    public Button resetButton;
    public Button submitButton;

    public Text potionText;
    private Potion resultPotion;

    // Start is called before the first frame update
    void Start()
    {
        potionList = GameObject.Find("GameManager").GetComponent<PotionList>().potionCatalog;

        showItemCount();

        resetButton.GetComponent<Button>().onClick.AddListener(resetComponents);
        submitButton.GetComponent<Button>().onClick.AddListener(submitPotion);
    }

    // Update is called once per frame
    void Update()
    {
        checkComponents();
    }

    void showItemCount()
    {
        int index;
        index = 0;
        foreach (KeyValuePair<Item, int> i in PlayerInventory.Inventory)
        {
            Components[index].GetComponentInChildren<Text>().text = i.Value.ToString();
            index++;
        }
    }

    void checkComponents()
    {
        if(componentItem1!= null && componentItem2 != null && componentItem3 != null)
        {
            foreach (Potion p in potionList)
            {
                if(p.components[0] == componentItem1 && p.components[1] == componentItem2 && p.components[2] == componentItem3)
                {
                    potionText.text = p.name;
                    resultPotion = p;
                    break;
                }
            }
        }
        else
        {
            potionText.text = "";
            resultPotion = null;
        }
    }

    public void selectComponent(int index)
    {
        if(componentItem1 == null)
        {
            componentItem1 = ItemList.itemCatalog[index];
            componentText1.text = ItemList.itemCatalog[index].Name;
        }
        else if(componentItem2 == null)
        {
            componentItem2 = ItemList.itemCatalog[index];
            componentText2.text = ItemList.itemCatalog[index].Name;
        }
        else if (componentItem3 == null)
        {
            componentItem3 = ItemList.itemCatalog[index];
            componentText3.text = ItemList.itemCatalog[index].Name;
        }
        else
        {

        }
    }

    void resetComponents()
    {
        componentItem1 = null;
        componentItem2 = null;
        componentItem3 = null;

        componentText1.text = "";
        componentText2.text = "";
        componentText3.text = "";
    }

    void submitPotion()
    {
        if (resultPotion != null) {
            GameObject.Find("Player").GetComponent<PlayerInventory>().removeItem(componentItem1);
            GameObject.Find("Player").GetComponent<PlayerInventory>().removeItem(componentItem2);
            GameObject.Find("Player").GetComponent<PlayerInventory>().removeItem(componentItem3);

            GameObject.Find("Player").GetComponent<PlayerInventory>().Gold += GameObject.Find("StoreManager").GetComponent<StoreManager>().current.Offer;

            if (GameObject.Find("StoreManager").GetComponent<StoreManager>().current.BestItem.name == resultPotion.name)
            {
                GameObject.Find("StoreManager").GetComponent<StoreManager>().ChangeReputation(4);
            }
            else
            {
                bool similarPotion = false;
                foreach(Potion p in GameObject.Find("StoreManager").GetComponent<StoreManager>().current.BestItem.similarPotions)
                {
                    if(p.name == resultPotion.name)
                    {
                        similarPotion = true;
                    }
                }
                if(similarPotion)
                {
                    GameObject.Find("StoreManager").GetComponent<StoreManager>().ChangeReputation(2);
                }
                else
                {
                    GameObject.Find("StoreManager").GetComponent<StoreManager>().ChangeReputation(-3);
                }
            }
            Debug.Log("Reputaion: " + GameObject.Find("StoreManager").GetComponent<StoreManager>().reputation);
            resetComponents();
            showItemCount();
            GameObject.Find("StoreManager").GetComponent<StoreManager>().ShowNextCustomer();
            GameObject.Find("StoreManager").GetComponent<StoreManager>().isCrafting = false;
        }
    }
}
