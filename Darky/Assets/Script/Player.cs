using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public GameObject _shadow;
    private GameObject[] _monsters;
    private Vector3 heal = new Vector3(1, 1, 1);

    public bool touched = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("LightPotion"))
        {
            _shadow.GetComponent<ShadowController>()._lightS.healLight(heal);
            Destroy(collision.gameObject);
        }

        if (collision.CompareTag("Coin"))
        {
            GameObject score = GameObject.FindGameObjectsWithTag("Score")[0];

            score.GetComponent<Score>().AddScore(500);
            Destroy(collision.gameObject);
            
        }
        if (collision.CompareTag("ErasePotion")) {
            _monsters = GameObject.FindGameObjectsWithTag("Monster");
            foreach (GameObject monster in _monsters) {
                _shadow.GetComponent<ShadowController>()._lightS.healLight(heal);
                monster.GetComponent<Die>().setDie();
            }
            Destroy(collision.gameObject);
        }
    }
}
