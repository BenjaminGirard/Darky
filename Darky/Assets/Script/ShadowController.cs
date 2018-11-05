using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadowController : MonoBehaviour {

    public LightSystem _lightS;

	void Start () {
        _lightS = new LightSystem(transform.localScale);
	}
	
	void Update () {
        
		transform.localScale = _lightS.damageLight(new Vector3(0.01f, 0.01f, 0.01f));
	}
}
