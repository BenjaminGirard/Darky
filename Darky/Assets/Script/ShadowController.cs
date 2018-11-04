using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadowController : MonoBehaviour {

    public LightSystem _lightS;

	void Start () {
        _lightS = new LightSystem(transform.localScale);
	}
	
	void Update () {
        transform.localScale = _lightS.getLight();
        if (transform.localScale.x > 0.535f)
            transform.localScale -= new Vector3(0.01f, 0.01f, 0.01f);
        _lightS.setLight(transform.localScale);
	}
}
