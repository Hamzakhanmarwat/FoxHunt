using System.Collections;
using System.Collections.Generic;
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
        
        if(collision.gameObject.tag == "Projectile")
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
        rb.AddForce(new Vector2(6, 4), ForceMode2D.Impulse);
        yield return new WaitForSeconds(2);
        //rb.gravityScale = 20;
        Instantiate(skull , rb.transform.position, Quaternion.identity);
        Destroy(rb.gameObject);
        Debug.Log("Yo");
    }
}