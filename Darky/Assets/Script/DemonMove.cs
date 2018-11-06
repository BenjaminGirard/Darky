using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemonMove : MonoBehaviour
{
    public float distAttack = 3f;
    public float speed = 2f;
	public GameObject player;
    public GameObject hitBox_att_right;
	private Animator anim;
    private bool is_att = false;
	
	void Start () {
        Physics2D.IgnoreCollision(player.GetComponent<Collider2D>(), this.GetComponent<Collider2D>());
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
        Vector3 dist = player.transform.position - transform.position;

        

        if (/*transform.position.x < player.transform.position.x && */dist.magnitude > distAttack)
		{
            desactiveHit();
            anim.SetBool("Att", false);
            transform.Translate(Vector2.left * speed * Time.deltaTime);

            BoxCollider2D[] tab = GetComponents<BoxCollider2D>();
            foreach (BoxCollider2D b in tab)
            {
                b.offset = new Vector2(-0.17f, -0.09f);
            }
            transform.eulerAngles = new Vector2(0, 0);
		}
        else
        {
            anim.SetBool("Att", true);
            GetComponent<BoxCollider2D>();
            BoxCollider2D[] tab = GetComponents<BoxCollider2D>();
            foreach (BoxCollider2D b in tab)
            {
                b.offset = new Vector2(0.217f, -0.332f);
            }

            print(AnimatorIsPlaying("Demon_attack"));

            if (AnimatorIsPlaying("Demon_attack") > 0.9)
            {
                desactiveHit();
            }
            else if (AnimatorIsPlaying("Demon_attack") > 0.5)
            {
                hitBox_att_right.SetActive(true);
            }
            //StartCoroutine(activeHit(0.5f));


        }

        /*
		else 
		{
			transform.Translate(Vector2.left * speed * Time.deltaTime);
			transform.eulerAngles = new Vector2(0, 0);
		}
        */
    }

    IEnumerator activeHit(float time)
    {
        yield return new WaitForSeconds(time);

            hitBox_att_right.SetActive(true);

    }

    void desactiveHit()
    {
            hitBox_att_right.SetActive(false);
    }

    float AnimatorIsPlaying(string stateName)
    {
        if (anim.GetCurrentAnimatorStateInfo(0).IsName(stateName))
            return (anim.GetCurrentAnimatorStateInfo(0).normalizedTime % 1.0f);
        return (0);
    }
}
