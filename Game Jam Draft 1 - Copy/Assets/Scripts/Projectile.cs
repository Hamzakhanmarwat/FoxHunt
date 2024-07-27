using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private bool isPressed = true;
    private float releaseDelay;
    private float maxDragDistance = 2f;
    public GameObject Slingshot;
    public int count = 10;
    public List<GameObject> points;
    public GameObject dot;
    public float dotDistance;
    SpriteRenderer spriteRenderer;

    private Rigidbody2D rb;
    private SpringJoint2D sj;
    private Rigidbody2D slingrb;
    private GameObject LifeObject;
    private LifeManager lifeManager;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        sj = GetComponent<SpringJoint2D>();
        releaseDelay = 1 / (sj.frequency * 4);
        slingrb = sj.connectedBody;
        LifeObject = GameObject.FindGameObjectWithTag("LifeController");
        lifeManager = LifeObject.GetComponent<LifeManager>();
        for (int i = 0; i <= count; i++)
        {
            GameObject Temp;
            Temp = Instantiate(dot, new Vector3(rb.position.x, rb.position.y, 1), Quaternion.identity);
            Temp.transform.parent = rb.transform;
            points.Add(Temp);
        }
    }
    void Update()
    {
        if (Input.touchCount > 0 && isPressed == true && Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position).x <= 18.5 && Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position).y <= 6.7)
        {
            DragBall(Input.GetTouch(0));
            
        }
    }
    private void DragBall(Touch touch)
    {
        Debug.Log(Camera.main.ScreenToWorldPoint(touch.position));
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(touch.position);
        rb.position = mousePosition;
        float distance = Vector2.Distance(mousePosition, slingrb.position);
        Debug.Log("HKKK");
        isPressed = true;
        rb.isKinematic = true;
        if (distance > maxDragDistance)
        {
            Vector2 direction = (mousePosition - slingrb.position).normalized;
            rb.position = slingrb.position + direction * maxDragDistance;
        }
        else
        {
            rb.position = mousePosition;
        }
        if (Input.GetTouch(0).phase == TouchPhase.Ended)
        {
            Up();
        }
        Vector3 firstdot = new Vector3(-rb.transform.localPosition.x, -rb.transform.localPosition.y, rb.transform.localPosition.z);
        for (int i = 0; i <= count; i++)
        {
            points[i].transform.position = new Vector3(rb.position.x, rb.position.y, 1) + firstdot * dotDistance * (i + 1);
        }
        GameObject[] arg = points.ToArray();
    }
    private void Up()
    {
        Debug.Log("OKK");
        isPressed = false;
        rb.isKinematic = false;
        for (int i = 0; i <= count; i++)
        {
            Destroy(points[i]);
        }
        StartCoroutine(Release());
    }

    private IEnumerator Release()
    {
        yield return new WaitForSeconds(releaseDelay);
        spriteRenderer.enabled = true;
        sj.enabled = false;
    }
    private IEnumerator destroy()
    {
        yield return new WaitForSeconds(1);
        //Vector3 pos = Spawner.transform.position;
        lifeManager.LifeReduce();
        if (lifeManager.lives != 0)
        {
            Debug.Log(lifeManager.lives);
            GameObject tempXI = Instantiate(Slingshot, rb.gameObject.transform.parent.position, Quaternion.identity);
            tempXI.transform.parent = rb.transform.parent.gameObject.transform.parent;
            Destroy(rb.gameObject.transform.parent.gameObject);
            Debug.Log("Respawn");
            
        }
        else
        {
            Destroy(rb.gameObject.transform.parent.gameObject);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(collision.collider.tag);
        if (collision.collider.tag == "Bounds")
        {
            if(collision.collider.tag == "Bounds")
            {
                //rb.bodyType = RigidbodyType2D.Static;
            }
            StartCoroutine(destroy());

        }
        else if (rb.velocity == Vector2.zero && isPressed == false && collision.gameObject.tag != "Bomb")
        {
            StartCoroutine(destroy());
        }
    }
}
