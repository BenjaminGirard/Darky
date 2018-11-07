using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Die : MonoBehaviour {

    private Animator anim;
    private bool die = false;
    public float time = 0.5f;
    private GameObject shadow;

    void Start()
    {
        anim = GetComponent<Animator>();
        shadow = GameObject.FindGameObjectWithTag("Shadow");
    }

    // Update is called once per frame
    void Update () {
		
	}

    public void setDie()
    {
        anim.SetBool("Die", true);
        StartCoroutine(Destroyz());
    }

    IEnumerator Destroyz()
    {
        yield return new WaitForSeconds(time);

        shadow.GetComponent<ShadowController>()._lightS.healLight(new Vector3(1f, 1f, 1f));
        GameObject.Destroy(this.transform.gameObject);

    }
}
