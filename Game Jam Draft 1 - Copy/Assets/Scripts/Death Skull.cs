using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathSkull : MonoBehaviour
{
    void Awake()
    {
        StartCoroutine(fade());
    }
    IEnumerator fade()
    {
        yield return new WaitForSeconds(2);
        Destroy(gameObject);
    }
        
}
