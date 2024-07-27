using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BounceSE : MonoBehaviour
{
    public float speedChange;
    [SerializeField] private GameObject pos;
    private GameObject projectile;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        projectile = collision.gameObject;
        projectile.transform.position = pos.transform.position;
        //speedChange = Mathf.Pow(speedChange, 0.5f);
        projectile.GetComponent<Rigidbody2D>().velocity = new Vector2(speedChange * 1f, speedChange * -1f);
    }
}
