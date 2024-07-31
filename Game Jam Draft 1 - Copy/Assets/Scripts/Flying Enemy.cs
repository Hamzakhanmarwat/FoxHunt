using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingEnemy : MonoBehaviour
{
    public Rigidbody2D rb;
    public GameObject projectile;
    public Collider2D thisCollider;
    public Animator animator;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        thisCollider = GetComponent<Collider2D>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "Projectile")
        {
            Debug.Log("Trigger");
            animator.SetBool("isDead", true);



            StartCoroutine(death());
        }
    }
    IEnumerator death()
    {
        yield return new WaitForSeconds(1.3f);
        Destroy(rb.gameObject);
    }
}
