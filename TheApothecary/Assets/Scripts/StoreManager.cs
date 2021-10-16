using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StoreManager : MonoBehaviour
{
    public Dictionary<Item, int> playerInventory;
    public List<Item> playerInventoryIndex;

    public List<Customer> customerList;
    public Customer current;
    public Text CustomerName;
    public Text CustomerDescription;
    public Text CustomerRequest;
    public Text CustomerOffer;

    public Button acceptButton;
    public Button declineButton;

    public GameObject craftingPanel;

    public int reputation;

    public bool isCrafting;


    // Start is called before the first frame update
    void Start()
    {
        reputation = 0;
        isCrafting = false;
        playerInventory = PlayerInventory.Inventory;
        playerInventoryIndex = PlayerInventory.inventoryIndex;

        customerList = new List<Customer>();

        Customer startCustomer = new Customer("Todd", "A very plain looking man", "Hey there, can you give me a basic potion? I just want to see if it works.", 50, GameObject.Find("GameManager").GetComponent<PotionList>().potionCatalog[0]);
        Customer NextCustomer = new Customer("Dave", "An ugly man", "What's up shugah tits, I need uh different potion from da last guy.", 30, GameObject.Find("GameManager").GetComponent<PotionList>().potionCatalog[1]);
        LoadCustomer(startCustomer);
        LoadCustomer(NextCustomer);
        LoadCustomer(new Customer("Jane", "An obvious lesbian", "Yo. I want a potion made just out of Lavender.", 30, GameObject.Find("GameManager").GetComponent<PotionList>().potionCatalog[2]));
        ShowNextCustomer();

        Button yesButton = acceptButton.GetComponent<Button>();
        Button noButton = declineButton.GetComponent<Button>();

        yesButton.onClick.AddListener(AcceptOffer);
        noButton.onClick.AddListener(DeclineOffer);
    }

    void Update()
    {
        ShowCrafting();
    }

    void ShowCrafting()
    {
        if(isCrafting)
        {
            craftingPanel.SetActive(true);
        }
        else
        {
            craftingPanel.SetActive(false);
        }
    }

    void AcceptOffer()
    {
        isCrafting = true;
        ChangeReputation(1);

    }

    void DeclineOffer()
    {
        ShowNextCustomer();
        ChangeReputation(-1);
    }

    public void ShowNextCustomer()
    {
        if(customerList.Count > 0)
        {
            current = customerList[0];

            CustomerName.text = current.Name;
            CustomerDescription.text = current.Description;
            CustomerRequest.text = current.RequestText;
            CustomerOffer.text = current.Offer.ToString();

            customerList.RemoveAt(0);
        }
        else
        {
            CustomerName.text = "";
            CustomerDescription.text = "";
            CustomerRequest.text = "There's no one here.";
            CustomerOffer.text = "";
        }
    }

    void LoadCustomer()
    {
        customerList.Add(new Customer());
    }
    void LoadCustomer(Customer c)
    {
        customerList.Add(c);
    }
    void LoadCustomer(string name, string description, string requestText, int offer, Potion bestItem)
    {
        customerList.Add(new Customer(name, description, requestText, offer, bestItem));
    }

    public void ChangeReputation(int change)
    {
        reputation += change;
    }
}
