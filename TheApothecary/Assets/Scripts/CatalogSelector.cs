using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatalogSelector : MonoBehaviour
{
    public bool catalogSelected;
    public GameObject catalog;

    // Start is called before the first frame update
    void Start()
    {
        catalogSelected = false;
    }

    private void Update()
    {
        if(catalogSelected)
        {
            if(Input.GetKeyDown(KeyCode.E))
            {
                catalog.GetComponent<Catalog>().OpenCloseCatalog();
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Catalog Collided");
        if(other.gameObject == catalog)
        {
            catalogSelected = true;
            this.gameObject.GetComponentInParent<PlayerShowInteract>().isShown = true;
            this.gameObject.GetComponentInParent<PlayerShowInteract>().ShowHideInteract();
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject == catalog)
        {
            catalogSelected = false;
            this.gameObject.GetComponentInParent<PlayerShowInteract>().isShown = false;
            this.gameObject.GetComponentInParent<PlayerShowInteract>().ShowHideInteract();
        }
    }
}
