using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Switch : MonoBehaviour
{
    [SerializeField] private GameObject switchobject;
    private Rigidbody2D thisObject;
    private Rigidbody2D switchrb;
    [SerializeField] private int time;
    [SerializeField] private int type; //type 1 = joint, type 2 = destory type 3 = move platform
    [SerializeField] private float speed;
    private Transform plat;
    private Transform target;

    private SpriteRenderer spriteRenderer;
    private Color green = Color.green;
    void Awake()
    {
        thisObject = GetComponent<Rigidbody2D>();
        switchrb = switchobject.GetComponent<Rigidbody2D>();
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.tag == "Sticky")
        {
            thisObject.bodyType = RigidbodyType2D.Static;
        }
        else if (collision.gameObject.tag == "Projectile")
        {
            collision.rigidbody.bodyType = RigidbodyType2D.Static;
            spriteRenderer.color = green;
            if (type == 1)
            {
                StartCoroutine(joint());
            }
            else if (type == 2)
            {
                StartCoroutine(despawn());

            }
            else if (type == 3)
            {
                plat = switchobject.transform.GetChild(0);
                target = switchobject.transform.GetChild(1);
                while (plat.position != target.position) {
                    plat.position = Vector2.Lerp(plat.position, target.position, speed * Time.deltaTime);
                    Debug.Log("Look what I've done for you");
                }
            }
        }
        IEnumerator joint()
        {
            yield return new WaitForSeconds(time);
            switchrb.bodyType = RigidbodyType2D.Dynamic;
        }
        IEnumerator despawn()
        {
            yield return new WaitForSeconds(time);
            Destroy(switchobject);
        }
    }
    private void OnDrawGizmos()
    {
        if(type == 3)
        {
            Gizmos.DrawLine(plat.position, target.position);
        }
    }
}
