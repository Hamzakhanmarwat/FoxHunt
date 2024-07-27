using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BounceS : MonoBehaviour
{
    public float speedChange;
    [SerializeField] private GameObject pos;
    private GameObject projectile;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        projectile = collision.gameObject;
        projectile.transform.position = pos.transform.position;
        projectile.GetComponent<Rigidbody2D>().velocity = new Vector2(0 , speedChange * -1f);

    }
}
