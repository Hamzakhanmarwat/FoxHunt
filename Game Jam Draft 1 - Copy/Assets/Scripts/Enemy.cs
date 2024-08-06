using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Rigidbody2D rb;
    private GameObject projectile;
    private Collider2D thisCollider;
    private Animator animator;
    private GameObject LifeObject;
    private LifeManager lifeManager;
    public GameObject skull;
    public bool reverse = false;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        thisCollider = GetComponent<Collider2D>();
        LifeObject = GameObject.FindGameObjectWithTag("LifeController");
        lifeManager = LifeObject.GetComponent<LifeManager>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if(collision.gameObject.tag == "Projectile" || collision.gameObject.tag == "Explosion" || collision.gameObject.tag == "Tree")
        {
            Debug.Log("Trigger");
            animator.SetBool("isDead", true);
            
            

            StartCoroutine(death());
        }
    }
    IEnumerator death()
    {
        lifeManager.enemyCount--;
        yield return new WaitForSeconds(0.2f);
        thisCollider.isTrigger = false;
        rb.bodyType = RigidbodyType2D.Dynamic;
        rb.drag = 2;
        if (!reverse)
        {
            rb.AddForce(new Vector2(9, 7), ForceMode2D.Impulse);
        }
        else
        {
            rb.AddForce(new Vector2(-9, -7), ForceMode2D.Impulse);
        }
        yield return new WaitForSeconds(0.2f);
        rb.gravityScale = 20;
        yield return new WaitForSeconds(2);
        Instantiate(skull , rb.transform.position, Quaternion.identity);
        Destroy(rb.gameObject);
        Debug.Log("Yo");
    }
}