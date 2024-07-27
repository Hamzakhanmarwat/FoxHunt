using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

public class TouchDemo : MonoBehaviour
{
    private Rigidbody2D cube;
    // Start is called before the first frame update
    void Awake()
    {
        cube = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.touchCount > 0 || Input.GetKeyDown(KeyCode.X))
        {
            Touch touch = Input.GetTouch(0);
            Debug.Log("Touched");
            if (Input.GetTouch(0).phase == TouchPhase.Ended)
            {
                Move(touch);
            }
        }
    }
    private void Move(Touch touch)
    {
        cube.position = Camera.main.ScreenToWorldPoint(touch.position);
    }

}
