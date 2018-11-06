using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NightmareMove : MonoBehaviour
{

	public GameObject player;
	private Animator anim;
	
	void Start () {
		anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		float hori = Input.GetAxis("Horizontal");

		movement(hori);
		anim.SetFloat("Hori", hori);
		//anim.SetBool("Att", Att);
	}

	void movement(float hori)
	{

		if (transform.position.x < player.transform.position.x)
		{
			transform.Translate(Vector2.right * 2f * Time.deltaTime);
			transform.eulerAngles = new Vector2(0, 0);
		}
		else 
		{
			transform.Translate(Vector2.left * 2f * Time.deltaTime);
			transform.eulerAngles = new Vector2(0, 0);
		}
	}



}
