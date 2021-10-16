using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadShop : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject == GameObject.Find("Player"))
        {
            collision.gameObject.transform.position = new Vector3(0f, 3.5f, 0f);
            SceneManager.LoadScene(1);
        }
    }
}
