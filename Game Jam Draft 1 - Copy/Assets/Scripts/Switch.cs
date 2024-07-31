using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour
{
    [SerializeField] private GameObject switchobject;
    private Rigidbody2D thisObject;
    private Rigidbody2D switchrb;
    [SerializeField] private int time;
    [SerializeField] private int type; //type 1 = joint, type 2 = destory

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
            spriteRenderer.color = green;
            if (type == 1)
            {
                StartCoroutine(joint(collision));
            }
            else if (type == 2)
            {
                StartCoroutine(despawn(collision));

            }
        }
        IEnumerator joint(Collision2D collision)
        {
            yield return new WaitForSeconds(time);
            switchrb.bodyType = RigidbodyType2D.Dynamic;
        }
        IEnumerator despawn(Collision2D collision)
        {
            yield return new WaitForSeconds(time);
            Destroy(switchobject);
        }
    }
}
