using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadFarm : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        this.gameObject.GetComponent<Button>().onClick.AddListener(loadFarm);
    }

    void loadFarm()
    {
        SceneManager.LoadScene(0);
    }
}
