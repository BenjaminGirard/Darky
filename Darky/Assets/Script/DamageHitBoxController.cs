using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageHitBoxController : MonoBehaviour {

    public GameObject shadow;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Hero"))
        {
            shadow.GetComponent<ShadowController>().DamageLight();
        }
    }
}

