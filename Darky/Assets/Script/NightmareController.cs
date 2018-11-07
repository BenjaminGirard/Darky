using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NightmareController : MonoBehaviour {

    public float speed = 10f;
    private GameObject player;

	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag("Hero");

        Physics2D.IgnoreCollision(player.GetComponent<Collider2D>(), this.GetComponent<Collider2D>());
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(Vector2.left * speed * Time.deltaTime);
    }
}
