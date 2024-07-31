using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UniversalBounce : MonoBehaviour
{
    public float speedChange;
    [SerializeField] private Transform pos;
    [SerializeField] private Transform target;
    private GameObject projectile;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        projectile = collision.gameObject;
        projectile.transform.position = pos.transform.position;
        Vector3 direction =  target.position - pos.position;
        direction = Vector3.Normalize(direction);
        Debug.Log(direction);
        projectile.GetComponent<Rigidbody2D>().velocity = direction * speedChange;
        Debug.Log("Bounce");

    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(pos.transform.position, target.position);
    }
}
