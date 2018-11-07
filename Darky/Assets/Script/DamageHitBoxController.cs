using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageHitBoxController : MonoBehaviour {

    private GameObject shadow;

    private void Awake()
    {
        shadow = GameObject.FindGameObjectWithTag("Shadow");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Hero"))
        {
            BlinkPlayer();
            shadow.GetComponent<ShadowController>().DamageLight();
        }
    }

    void BlinkPlayer() {
        Renderer r = GameObject.FindGameObjectWithTag("Hero").GetComponent<Renderer>();
        StartCoroutine(DoBlinks(r));
        if (!r.enabled)
            r.enabled = true;
    }
    
        IEnumerator DoBlinks(Renderer r) {
        
        r.enabled = false;
        yield return new WaitForSeconds(0.2f);
        r.enabled = true;
        yield return new WaitForSeconds(0.2f);
        r.enabled = false;
        yield return new WaitForSeconds(0.2f);
        r.enabled = true;
     }
}

