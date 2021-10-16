using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlotSelector : MonoBehaviour
{
    public GameObject farmManager;
    public LayerMask farmLayer;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //transform.position = new Vector3(transform.position.x + (Input.GetAxisRaw("Horizontal") * .15f), transform.position.y + (Input.GetAxisRaw("Vertical") * .15f));
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Farm"))
        {
            Debug.Log("Collided");
            farmManager.GetComponent<FarmManager>().SelectPlot(collision.gameObject);

            this.gameObject.GetComponentInParent<PlayerShowInteract>().isShown = true;
            this.gameObject.GetComponentInParent<PlayerShowInteract>().ShowHideInteract();
        }
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Farm"))
        {
            Debug.Log("Stopped colliding");
            farmManager.GetComponent<FarmManager>().SelectPlot(null);

            this.gameObject.GetComponentInParent<PlayerShowInteract>().isShown = false;
            this.gameObject.GetComponentInParent<PlayerShowInteract>().ShowHideInteract();
        }
    }
}
