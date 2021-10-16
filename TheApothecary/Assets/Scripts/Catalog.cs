using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Catalog : MonoBehaviour
{
    public Item[] itemCatalog;
    public Canvas CatalogCanvas;
    public Canvas IngameCanvas;
    public bool isOpen;

    public Button nextButton;
    public Button backButton;

    public Button exitButton;

    public Text firstName;
    public Text firstDesc;
    public Text firstCost;
    public Button firstPurchase;
    public Text secondName;
    public Text secondDesc;
    public Text secondCost;
    public Button secondPurchase;

    public int pageNumber;

    public Item firstItem;
    public Item secondItem;

    public GameObject Player;
    void Start()
    {
        Button nxtButton = nextButton.GetComponent<Button>();
        Button bckButton = backButton.GetComponent<Button>();

        Button xtButton = exitButton.GetComponent<Button>();

        Button fstButton = firstPurchase.GetComponent<Button>();
        Button scndButton = secondPurchase.GetComponent<Button>();

        nxtButton.onClick.AddListener(NextPage);
        bckButton.onClick.AddListener(BackPage);

        xtButton.onClick.AddListener(OpenCloseCatalog);

        fstButton.onClick.AddListener(PurchaseFirst);
        scndButton.onClick.AddListener(PurchaseSecond);

        pageNumber = 0;
        CatalogCanvas.enabled = false;
        isOpen = false;

    }

    void NextPage()
    {
        if(pageNumber  < ItemList.itemCatalog.Length -2)
        {
            pageNumber+=2;
            updateUI();
        }
    }
    void BackPage()
    {
        if (pageNumber > 0)
        {
            pageNumber-=2;
            updateUI();
        }
    }

    void updateUI()
    {
        firstName.text = ItemList.itemCatalog[pageNumber].Name;
        firstDesc.text = ItemList.itemCatalog[pageNumber].Description;
        firstCost.text = ItemList.itemCatalog[pageNumber].Cost.ToString();

        secondName.text = ItemList.itemCatalog[pageNumber + 1].Name;
        secondDesc.text = ItemList.itemCatalog[pageNumber + 1].Description;
        secondCost.text = ItemList.itemCatalog[pageNumber + 1].Cost.ToString();
    }

    public void OpenCloseCatalog()
    {
        if(!isOpen)
        {
            isOpen = !isOpen;
            CatalogCanvas.enabled = true;
            IngameCanvas.enabled = false;
            Time.timeScale = 0.0f;
            updateUI();
        }
        else
        {
            isOpen = !isOpen;
            CatalogCanvas.enabled = false;
            IngameCanvas.enabled = true;
            Time.timeScale = 1.0f;
            pageNumber = 0;
        }
    }

    void PurchaseFirst()
    {
        if (Player.GetComponent<PlayerInventory>().Gold >= ItemList.itemCatalog[pageNumber].Cost)
        {
            Player.GetComponent<PlayerInventory>().addItem(ItemList.itemCatalog[pageNumber]);
            Player.GetComponent<PlayerInventory>().Gold = Player.GetComponent<PlayerInventory>().Gold - ItemList.itemCatalog[pageNumber].Cost;
        }
    }
    void PurchaseSecond()
    {
        if (Player.GetComponent<PlayerInventory>().Gold >= ItemList.itemCatalog[pageNumber + 1].Cost)
        {
            Player.GetComponent<PlayerInventory>().addItem(ItemList.itemCatalog[pageNumber + 1]);
            Player.GetComponent<PlayerInventory>().Gold = Player.GetComponent<PlayerInventory>().Gold - ItemList.itemCatalog[pageNumber + 1].Cost;
        }
    }
}
