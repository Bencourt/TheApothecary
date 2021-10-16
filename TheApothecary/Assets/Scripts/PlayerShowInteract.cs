using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShowInteract : MonoBehaviour
{
    public GameObject interactBubble;

    public bool isShown;

    // Start is called before the first frame update
    void Start()
    {
        isShown = false;
    }

    public void ShowHideInteract()
    {
        if(isShown)
        {
            interactBubble.GetComponent<SpriteRenderer>().enabled = true;
        }
        else
        {
            interactBubble.GetComponent<SpriteRenderer>().enabled = false;

        }
    }
}
