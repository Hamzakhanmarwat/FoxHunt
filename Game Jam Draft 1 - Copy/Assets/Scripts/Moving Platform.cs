using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public Transform start;
    public Transform end;
    public Transform plat;
    public float speed = 1.5f;
    private int direction = 1;
    void Update()
    {
        Vector2 target = currentLocation();

        plat.position = Vector2.Lerp(plat.position, target, speed * Time.deltaTime);

        float distance = (target - (Vector2)plat.position).magnitude;

        if(distance <= 0.1f)
        {
            direction *= -1;
        }

    }

    Vector2 currentLocation()
    {
        if (direction == 1)
        {
            return start.position;
        }
        else
        {
            return end.position;
        }
    }
    private void OnDrawGizmos()
    {
        if(plat != null && start != null && end != null)
        {
            Gizmos.DrawLine(plat.transform.position, start.transform.position);
            Gizmos.DrawLine(plat.transform.position, end.transform.position);
        }
    }
}
