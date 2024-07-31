using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private bool isPressed = true; //becomes false when the slingshot is released
    private float releaseDelay; // delay between release and launch
    private float maxDragDistance = 2f; // radius around which slingshot can be dragged

    public GameObject Slingshot; //prefab object to be instantiated
    public int count = 10; // number of dots in predicted path
    public List<GameObject> points; // list for dots
    public GameObject dot; // dots prefab
    public float dotDistance; //distance between dots
    SpriteRenderer spriteRenderer; // sprite renderer of slingshot

    private Rigidbody2D rb; // rigidbody of projectile
    private SpringJoint2D sj; // springjoint of slingshot
    private Rigidbody2D slingrb; // rigidbody of sling
    private Transform thisTransform; //transform of projectile

    private GameObject LifeObject; //Life Controller Object
    private LifeManager lifeManager; //Access Life Controller Script
    private GameObject Arm;
    private Arm arm;

    private bool isStarted = false; // becomes true when the destroy() coroutine starts. exists to prevent multiple calls
    private Vector3 vector3; //spawn point

    private GameObject Player; //player GameObject
    

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        sj = GetComponent<SpringJoint2D>();
        releaseDelay = 1 / (sj.frequency * 4);
        slingrb = sj.connectedBody;
        LifeObject = GameObject.FindGameObjectWithTag("LifeController");
        lifeManager = LifeObject.GetComponent<LifeManager>();
        thisTransform = rb.transform;
        vector3 = thisTransform.position;
        Player = GameObject.FindGameObjectWithTag("Player");
        Arm = GameObject.FindGameObjectWithTag("Arm");
        arm = Arm.GetComponent<Arm>();
        arm.isReleased = false;

        for (int i = 0; i <= count; i++) // instantiate dots for projectile preview
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
    private void DragBall(Touch touch) // used to drag slingshot and show predicted path
    {
        Debug.Log(Camera.main.ScreenToWorldPoint(touch.position));
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(touch.position);
        rb.position = mousePosition;
        float distance = Vector2.Distance(mousePosition, slingrb.position);
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
            points[i].transform.position = new Vector3(rb.position.x, rb.position.y, 1) + firstdot * dotDistance * (i + 2);
        }
        GameObject[] arg = points.ToArray();
    }

    private void Up() // called when slingshot is released
    {
        arm.isReleased = true;
        isPressed = false;
        rb.isKinematic = false;
        for (int i = 0; i <= count; i++)
        {
            Destroy(points[i]);
        }
        StartCoroutine(Release());
    }

    private IEnumerator Release() // started when slingshot is released
    {
        yield return new WaitForSeconds(releaseDelay);
        spriteRenderer.enabled = true;
        sj.enabled = false;
        rb.drag = 0.2f;
    }
    private IEnumerator destroy() // started to destroy and respawn new slingshot
    {
        yield return new WaitForSeconds(2);
        lifeManager.LifeReduce(); // reduces life by 1
        if (lifeManager.lives != 0)
        {
            Debug.Log(lifeManager.lives);
            GameObject tempXI = Instantiate(Slingshot, vector3, Quaternion.identity);
            tempXI.transform.parent = Player.transform;
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
        if ((collision.collider.tag == "Bounds" && !isStarted)) //colliding with bounds means immediate respwan
        {
            isStarted = true;
            StartCoroutine(destroy());
        }
        if ((collision.collider.tag == "Sticky" && !isStarted)) //colliding with sticky means immediate respwan
        {
            isStarted = true;
            StartCoroutine(destroy());
        }
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (rb.velocity.magnitude <= 0.05 && isPressed == false && collision.gameObject.tag != "Bomb" && !isStarted) // when projectile is in contact with a surface and has near 0 velocity
        {
            isStarted = true;
            StartCoroutine(destroy());
        }
    }
       
 }
