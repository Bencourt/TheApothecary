using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroyOnLoad : MonoBehaviour
{
    // Start is called before the first frame update
    private static GameObject Instance;
    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);

        if (Instance == null)
        {
            Instance = this.gameObject;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
}
