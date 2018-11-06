using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour {

    Animator anim;
    bool Att = false;
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
        if (hori < 0)
        {
            anim.SetBool("Right", false);
        }
        else if (hori > 0)
            anim.SetBool("Right", true);
        /*
        if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector2.down * 3f * Time.deltaTime);
            transform.eulerAngles = new Vector2(0, 0);
        }
        */
        if (Input.GetKey(KeyCode.UpArrow)/* || Input.GetKeyDown(KeyCode.Z)*/)
        {
            //Att = true;
            anim.SetBool("Att", true);
        }
        else
        {
            //Att = false;
            anim.SetBool("Att", false);
        }

        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector2.right * 5f * Time.deltaTime);
            transform.eulerAngles = new Vector2(0, 0);
        }
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.Q))
        {
            transform.Translate(Vector2.left * 5f * Time.deltaTime);
            transform.eulerAngles = new Vector2(0, 0);
        }
    }



}
