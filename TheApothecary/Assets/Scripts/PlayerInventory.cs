using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerInventory : MonoBehaviour
{
    public static Dictionary<Item, int> Inventory;
    public static List<Item> inventoryIndex;
    private int gold;

    public Item selected;
    public GameObject[] inventoryGameObjects;
    public Text[] inventoryText;

    public Text goldText;

    void Start()
    {
        gold = 50;
        Inventory = new Dictionary<Item, int>();
        inventoryIndex = new List<Item>();

        addItem(ItemList.itemCatalog[0], 4);
        selected = inventoryIndex[0];
        FindUI();
    }

    void Update()
    {
        SelectInventory();
        UpdateInventoryUI();
    }

    void FindUI()
    {
        inventoryGameObjects = GameObject.FindGameObjectsWithTag("InventoryText");
        inventoryText = new Text[inventoryGameObjects.Length];

        int index = 0;
        foreach (GameObject g in inventoryGameObjects)
        {
            inventoryText[index] = g.GetComponent<Text>();
            index++;
        }

        goldText = GameObject.FindGameObjectWithTag("GoldText").GetComponent<Text>();
    }

    void UpdateInventoryUI()
    {
        if (GameObject.Find("FarmUI") != null)
        {
            for (int i = 0; i < inventoryText.Length; i++)
            {
                if (i < inventoryIndex.Count)
                {
                    inventoryText[i].text = inventoryIndex[i].Name + ": " + Inventory[inventoryIndex[i]];
                }
                else
                {
                    inventoryText[i].text = "empty slot";
                }
            }

            if (goldText != null)
            {
                goldText.text = gold.ToString();
            }
        }
    }
    void SelectInventory()
    {
        if(inventoryText.Length > 0)
        {
            FindUI();
        }

        if (GameObject.Find("FarmUI") != null)
        {
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                if (inventoryIndex.IndexOf(selected) == 0)
                {
                    selected = inventoryIndex[inventoryIndex.Count - 1];
                }
                else
                {
                    selected = inventoryIndex[inventoryIndex.IndexOf(selected) - 1];
                }
            }
            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                if (inventoryIndex.IndexOf(selected) == inventoryIndex.Count - 1)
                {
                    selected = inventoryIndex[0];
                }
                else
                {
                    selected = inventoryIndex[inventoryIndex.IndexOf(selected) + 1];
                }
            }

            for (int i = 0; i < inventoryText.Length; i++)
            {
                if (i < inventoryIndex.Count)
                {
                    if (selected == inventoryIndex[i])
                    {
                        inventoryText[i].color = Color.cyan;
                    }
                    else
                    {
                        inventoryText[i].color = Color.black;
                    }
                }
            }
        }
    }

    public int Gold
    {
        get { return gold; }
        set { gold = value; }
    }

    public void addItem(Item item)
    {
        if(Inventory.ContainsKey(item))
        {
            if (Inventory[item] > 0)
            {
                Inventory[item]++;
            }
            else
            {
                Inventory[item]++;
                inventoryIndex.Add(item);
                if (selected == null)
                {
                    selected = item;
                }
            }
        }
        else
        {
            Inventory.Add(item, 1);
            inventoryIndex.Add(item);
            if (selected == null)
            {
                selected = item;
            }
        }
    }

    public void addItem(Item item, int count)
    {
        if (Inventory.ContainsKey(item))
        {
            if (Inventory[item] > 0)
            {
                Inventory[item] += count;
            }
            else
            {
                Inventory[item] += count;
                inventoryIndex.Add(item);
                if (selected == null)
                {
                    selected = item;
                }
            }
        }
        else
        {
            Inventory.Add(item, count);
            inventoryIndex.Add(item);
            if (selected == null)
            {
                selected = item;
            }
        }
    }

    public void removeItem(Item item)
    {
        if(Inventory.ContainsKey(item))
        {
            if(Inventory[item] > 0)
            {
                if (Inventory[item] == 1)
                {
                    if(inventoryIndex.IndexOf(item) != 0)
                    {
                        selected = inventoryIndex[inventoryIndex.IndexOf(item) - 1];
                    }
                    else if(inventoryIndex.IndexOf(item) == 0)
                    {
                        if(inventoryIndex.Count > 1)
                        {
                            selected = inventoryIndex[1];
                        }
                        else
                        {
                            selected = null;
                        }
                    }
                    inventoryIndex.Remove(item);
                }
                Inventory[item] = Inventory[item] - 1;
            }
        }
    }

    private Scene lastScene;
    void onSceneChange()
    {
        if(lastScene != SceneManager.GetActiveScene())
        {
            if(SceneManager.GetActiveScene() == SceneManager.GetSceneByBuildIndex(0))
            {
                FindUI();
            }
        }
        lastScene = SceneManager.GetActiveScene();
    }
}
