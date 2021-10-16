using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CraftingButton : MonoBehaviour
{
    public int index;
    public GameObject craftingUI;
    // Start is called before the first frame update
    void Start()
    {
        this.gameObject.GetComponent<Button>().onClick.AddListener(selectComponent);
    }
    void selectComponent()
    {
        craftingUI.GetComponent<Crafting>().selectComponent(index);
    }
}
