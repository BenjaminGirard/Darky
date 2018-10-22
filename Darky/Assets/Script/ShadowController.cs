using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadowController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (transform.localScale.x > 0.535f)
            transform.localScale -= new Vector3(0.01f, 0.01f, 0.01f);
	}
}
