using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class PlayerMove : MonoBehaviour {

    Animator anim;
    public GameObject hitBox_att_right;
    public GameObject hitBox_att_left;
    bool Att = false;
    bool left = false;
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
            left = true;
            anim.SetBool("Right", false);
        }
        else if (hori > 0)
        {
            left = false;
            anim.SetBool("Right", true);
        }
        /*
        if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector2.down * 3f * Time.deltaTime);
            transform.eulerAngles = new Vector2(0, 0);
        }
        */
        if (Input.GetKey(KeyCode.UpArrow)/* || Input.GetKeyDown(KeyCode.Z)*/)
        {
            Att = true;
            anim.SetBool("Att", true);
            StartCoroutine(activeHit(0.3f));
            StartCoroutine(desactiveHit(0.5f));
            //hitBox_att.SetActive(false);
        }
        else
        {
            Att = false;
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

    IEnumerator activeHit(float time)
    {
        yield return new WaitForSeconds(time);

        if (left)
            hitBox_att_left.SetActive(true);
        else
            hitBox_att_right.SetActive(true);

    }

    IEnumerator desactiveHit(float time)
    {
        yield return new WaitForSeconds(time);

            hitBox_att_left.SetActive(false);
            hitBox_att_right.SetActive(false);
    }
}
