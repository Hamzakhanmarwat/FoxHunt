using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arm : MonoBehaviour
{
    public GameObject player;
    public bool isReleased = false;
    void Update()
    {
        if (Input.touchCount > 0 && !isReleased)
        {
            Vector3 difference = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position) - transform.position;
            difference.Normalize();
            float rotationZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0, 0, rotationZ - 90);

            /*if(rotationZ < -90 || rotationZ > 90)
            {
                if (player.transform.eulerAngles.y == 0)
                {
                    transform.localRotation = Quaternion.Euler(180, 0, -rotationZ);
                }
                else if (player.transform.eulerAngles.y == 180)
                {
                    transform.localRotation = Quaternion.Euler(180, 180, -rotationZ);
                }
            }*/
            
        }
    }
}
