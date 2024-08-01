using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portals : MonoBehaviour
{
    public float speedChange;
    [SerializeField] private Transform PurplePortal;
    [SerializeField] private Transform Direction;
    private GameObject projectile;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        projectile = collision.gameObject;
        projectile.transform.position = PurplePortal.transform.position;
        Vector3 direction = Direction.position - PurplePortal.position;
        direction = Vector3.Normalize(direction);
        projectile.GetComponent<Rigidbody2D>().velocity = direction * speedChange;
        Debug.Log(direction * speedChange);
        Debug.Log("Teleport");

    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(PurplePortal.transform.position, Direction.position);
    }
}
