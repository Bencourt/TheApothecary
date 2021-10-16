using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FarmPlot : MonoBehaviour
{
    public bool isEmpty;
    public Item growingItem;
    public int growTime;
    public int growState;
    public bool isSelected;

    // Start is called before the first frame update
    void Start()
    {
        growTime = 0;
        growState = 0;
        growingItem = null;
        isEmpty = true;
        isSelected = false;
        Select();
    }

    private void Update()
    {
        Select();
    }

    public void startGrowing(Item item)
    {
        growingItem = item;
        growState = 1;
        isEmpty = false;
        growTime = 0;
    }

    public void harvest()
    {
        growingItem = null;
        growState = 0;
        isEmpty = true;
        growTime = 0;
    }

    public void Select()
    {
        if(isSelected)
        {
            gameObject.GetComponent<SpriteRenderer>().color = Color.red;
        }
        else
        {
            if (isEmpty)
            {
                gameObject.GetComponent<SpriteRenderer>().color = Color.white;
            }
            else
            {
                if (growState == 1)
                {
                    gameObject.GetComponent<SpriteRenderer>().color = Color.green;
                }
                else if(growState == 2)
                {
                    gameObject.GetComponent<SpriteRenderer>().color = Color.yellow;
                }
                else
                {
                    gameObject.GetComponent<SpriteRenderer>().color = Color.white;
                }
            }
        }
    }

}
