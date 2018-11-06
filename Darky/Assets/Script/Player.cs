using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public GameObject _shadow;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("LightPotion"))
        {
            _shadow.GetComponent<ShadowController>()._lightS.healLight(new Vector3(1, 1, 1));
            Destroy(collision.gameObject);
        }

        if (collision.CompareTag("Coin"))
        {
            GameObject score = GameObject.FindGameObjectsWithTag("Score")[0];

            score.GetComponent<Score>().AddScore(500);
            Destroy(collision.gameObject);
            
        }
        
    }
}
