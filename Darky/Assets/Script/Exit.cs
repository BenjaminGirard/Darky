using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenutQuit : MonoBehaviour {

	void Update () {
		 if (Input.GetKey("escape")) {
            Application.Quit();
        }
	}

	public void QuitOnClick() {
		Application.Quit();
	}
}
