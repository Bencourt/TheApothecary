using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerActiveCheck : MonoBehaviour
{
    public GameObject Player;

    Scene currentScene;
    // Start is called before the first frame update
    void Start()
    {
        currentScene = SceneManager.GetActiveScene();
    }

    // Update is called once per frame
    void Update()
    {
        CheckScene();
    }
    
    void CheckScene()
    {
        currentScene = SceneManager.GetActiveScene();
        if(currentScene == SceneManager.GetSceneByBuildIndex(0))
        {
            Player.GetComponent<PlayerMovement>().enabled = true;
            Player.GetComponent<SpriteRenderer>().enabled = true;
        }
        else if(currentScene == SceneManager.GetSceneByBuildIndex(1))
        {
            Player.GetComponent<PlayerMovement>().enabled = false;
            Player.GetComponent<SpriteRenderer>().enabled = false;
        }
    }
}
