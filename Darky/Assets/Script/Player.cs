using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public GameObject _shadow;

	void Start () {
		
	}
	
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        print("yo");
        if (collision.CompareTag("LightPotion"))
        {
            _shadow.GetComponent<ShadowController>()._lightS.healLight(new Vector3(1, 1, 1));
            Destroy(collision.gameObject);
        }
    }
}
