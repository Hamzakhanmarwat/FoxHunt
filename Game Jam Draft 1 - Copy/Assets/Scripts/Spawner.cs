using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject sling;
    private GameObject spawn;
    // Start is called before the first frame update
    void Start()
    {
        spawn = GetComponent<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            Instantiate(sling);
            Debug.Log(spawn.transform.position);
        }
    }
}
