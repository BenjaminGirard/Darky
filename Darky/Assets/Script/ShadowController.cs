using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ShadowController : MonoBehaviour {

    public LightSystem _lightS;
    private float _minLightScale;
    public GameObject score;
	void Start () {
        _lightS = new LightSystem(transform.localScale);
        _minLightScale = _lightS.getMinLightScale();
	}
	
	void Update () {
        
		transform.localScale = _lightS.damageLight(new Vector3(0.01f, 0.01f, 0.01f));
        if (_lightS.getLight().x <= _minLightScale) {
            PlayerPrefs.SetInt("highScore", score.GetComponent<Score>().getScore());
            PlayerPrefs.Save();
            SceneManager.LoadScene(2);
        }
	}

    public void DamageLight()
    {
        _lightS.damageLight(new Vector3(0.4f, 0.4f, 0.4f));
    }
}
