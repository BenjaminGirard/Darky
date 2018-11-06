using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkullController : MonoBehaviour {

    Vector3 pos;
    public float speed = 10f;
    public float frequency = 10f;
    public float magnitude = 10f;

    void Start () {
        pos = transform.position;
	}
	
	void Update () {
        pos -= transform.right * Time.deltaTime * speed;
        transform.position = pos + transform.up * Mathf.Sin(Time.time * frequency) * magnitude;

	}
}
