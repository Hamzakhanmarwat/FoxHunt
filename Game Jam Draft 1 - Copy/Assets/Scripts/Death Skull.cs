using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathSkull : MonoBehaviour
{
    private Color alphacolor;
    private SpriteRenderer spriteRenderer;
    private float step = 0.05f;
    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        StartCoroutine(fade());
    }
    IEnumerator fade()
    {
        /*yield return new WaitForSeconds(0.1f);
        alphacolor.a -= step;
        spriteRenderer.color = alphacolor;
        if (alphacolor.a <= 0f) {
        StartCoroutine(fade()); */
        yield return new WaitForSeconds(2);
        Destroy(spriteRenderer.gameObject);
    }
        
}
