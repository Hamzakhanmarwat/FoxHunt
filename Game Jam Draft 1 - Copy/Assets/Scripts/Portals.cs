using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portals : MonoBehaviour
{
    public float speedChange;
    [SerializeField] private Transform PurplePortal;
    [SerializeField] private Transform Direction;
    private GameObject projectile;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        projectile = collision.gameObject;
        Vector3 speed = projectile.gameObject.GetComponent<Rigidbody2D>().velocity;
        float speedChange = speed.magnitude;
        projectile.transform.position = PurplePortal.transform.position;
        Vector3 direction = Direction.position - PurplePortal.position;
        direction = Vector3.Normalize(direction);
        projectile.GetComponent<Rigidbody2D>().velocity = direction * speedChange;
        Debug.Log(direction * speedChange);

        AudioManager.Instance.PlaySFX("Teleport Enter");
        Debug.Log("Teleport");

    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(PurplePortal.transform.position, Direction.position);
    }
}
