using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FarmManager : MonoBehaviour
{
    public int day;
    public float timer;
    public int minutesPerDay;
    public GameObject[] farmPlots;
    public GameObject player;

    void Start()
    {
        day = 0;
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if(timer >= 15.0f)
        {
            timer = 0.0f;
            Debug.Log("time elapsed: " + Time.time);
            day++;
            Grow();
        }
        CheckGrow();
    }

    void CheckGrow()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            foreach (GameObject g in farmPlots)
            {
                if(g.GetComponent<FarmPlot>().isSelected)
                {
                    if (g.GetComponent<FarmPlot>().isEmpty)
                    {
                        if (player.GetComponent<PlayerInventory>().selected != null)
                        {
                            g.GetComponent<FarmPlot>().startGrowing(player.GetComponent<PlayerInventory>().selected);
                            player.GetComponent<PlayerInventory>().removeItem(player.GetComponent<PlayerInventory>().selected);
                        }
                    }
                    else
                    {
                        if (g.GetComponent<FarmPlot>().growState == 2)
                        {
                            player.GetComponent<PlayerInventory>().addItem(g.GetComponent<FarmPlot>().growingItem, 3);
                            g.GetComponent<FarmPlot>().harvest();
                        }
                    }
                }
            }
        }
    }

    void Grow()
    {
        foreach(GameObject g in farmPlots)
        {
            if (!g.GetComponent<FarmPlot>().isEmpty)
            {
                if (g.GetComponent<FarmPlot>().growTime < g.GetComponent<FarmPlot>().growingItem.Time)
                {
                    g.GetComponent<FarmPlot>().growTime++;
                }
                else
                {
                    g.GetComponent<FarmPlot>().growState = 2;
                }
            }
        }
    }

    public void SelectPlot(GameObject selected)
    {
        int i = 0;
        foreach (GameObject g in farmPlots)
        {
            i++;
            if (selected == g)
            {
                Debug.Log("Selected plot " + i);
                g.GetComponent<FarmPlot>().isSelected = true;
            }
            else
            {
                g.GetComponent<FarmPlot>().isSelected = false;
            }
            g.GetComponent<FarmPlot>().Select();
        }
    }
}
