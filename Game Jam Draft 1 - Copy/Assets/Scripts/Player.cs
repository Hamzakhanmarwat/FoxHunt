using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private LifeManager lifeManager;
    private GameObject LifeObject;
    void Awake()
    {
        LifeObject = GameObject.FindGameObjectWithTag("LifeController");
        Physics2D.IgnoreLayerCollision(3, 6);
        lifeManager = LifeObject.GetComponent<LifeManager>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Bomb")
        {
            lifeManager.Death();
        }
    }
}
