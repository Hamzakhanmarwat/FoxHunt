using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Rigidbody2D rb;
    private GameObject projectile;
    private Collider2D thisCollider;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        projectile = collision.gameObject;
        if (projectile.tag != "Immune")
        {
            Destroy(rb.gameObject);
        }
    }
}