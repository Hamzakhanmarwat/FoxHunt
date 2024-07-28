using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    public Collider2D thisobject;
    private GameObject[] explodeable;
    private float radius = 5f;
    private void Awake()
    {
        explodeable = GameObject.FindGameObjectsWithTag("Explodable");
        thisobject = GetComponent<Collider2D>();
        StartCoroutine(despawn());
        Debug.Log("I'm Alive");
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Collider2D[] objects = Physics2D.OverlapCircleAll(transform.position, radius);
        foreach (Collider2D obj in objects)
        {
            if (obj.tag == "Explodable") {
            Destroy(obj.gameObject);
        }

        }
    }
    IEnumerator despawn()
    {
        yield return new WaitForSeconds(0.75f);
        Debug.Log(thisobject);
        Destroy(thisobject.gameObject);
        
        
        
    }
}
