using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    [SerializeField] private GameObject explosion;
    private Rigidbody2D rb;
    private int trigger = 1;
    private bool dead = false;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player" && trigger == 1)
        {
            Instantiate(explosion, rb.transform.position, Quaternion.identity);
            trigger--;
            dead = true;
            Destroy(collision.transform.parent.gameObject);
            Destroy(rb.gameObject);
        }
        else if (collision.gameObject.tag == "Projectile" && trigger == 1 && !dead)
        {
            Instantiate(explosion, rb.transform.position,Quaternion.identity );
            trigger--;
            Destroy(rb.gameObject);
        }
        

    }
}
