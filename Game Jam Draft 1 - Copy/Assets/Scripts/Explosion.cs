using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    public Collider2D thisobject;
    private GameObject explodeable;
    private GameObject key;
    public GameObject keyui;
    private void Awake()
    {
        explodeable = GameObject.FindGameObjectWithTag("Explodable");
        key = GameObject.FindGameObjectWithTag("Key");
        thisobject = GetComponent<Collider2D>();
        StartCoroutine(despawn());
        Debug.Log("I'm Alive");
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag != "Player") {
        Destroy(explodeable);
        Instantiate(keyui);
        Destroy(key);
        }


        Debug.Log("Im dead");
    }

    IEnumerator despawn()
    {
        yield return new WaitForSeconds(0.75f);
        Debug.Log(thisobject);
        Destroy(thisobject.gameObject);
        
        
        
    }
}
