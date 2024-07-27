using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeManager : MonoBehaviour
{
    public int lives = 3;
    public GameObject[] Life;
    private int lifeinverse = 0;
    // Start is called before the first frame update
    void Awake()
    {
        Life = GameObject.FindGameObjectsWithTag("Life");
    }

    // Update is called once per frame
    public void LifeReduce()
    {
        Destroy(Life[lifeinverse]);
        lifeinverse++;
        lives--;
    }
    public void Death()
    {
        while (lives != 0)
        {
            Destroy(Life[lifeinverse]);
            lifeinverse++;
            lives--;
        }
    }
}
