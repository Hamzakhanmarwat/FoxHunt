using System.Collections;
using System.Collections.Generic;
using UnityEditor.Tilemaps;
using UnityEngine;

public class LifeManager : MonoBehaviour
{
    public int lives = 3;
    private GameObject[] Life;
    private int lifeinverse = 0;
    private GameObject[] Enemies;
    public int enemyCount;
    private bool messageShown = false;
    // Start is called before the first frame update
    void Awake()
    {
        Life = GameObject.FindGameObjectsWithTag("Life");
        Enemies = GameObject.FindGameObjectsWithTag("Enemy");
        enemyCount = Enemies.Length;
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
    public void Update()
    {
        if(enemyCount == 0 && messageShown == false)
        {
            Debug.Log("Level Complete");
            messageShown = true;
        }
        else if(lives == 0 && messageShown == false)
        {
            Debug.Log("Level Failed");
            messageShown = true;
        }
    }
}
