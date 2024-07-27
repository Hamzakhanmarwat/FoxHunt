using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sticky : MonoBehaviour
{
    [SerializeField] private GameObject pos;
    private GameObject projectile;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        projectile = collision.gameObject;
        projectile.transform.position = pos.transform.position;
        projectile.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
    }
}
