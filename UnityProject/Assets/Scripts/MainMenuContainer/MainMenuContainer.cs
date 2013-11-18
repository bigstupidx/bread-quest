using UnityEngine;
using System.Collections;

public class MainMenuContainer : MonoBehaviour {

	void Update () {
		if (Input.GetButton("Fire1")
		    || Input.GetButton("Enter")
		    || Input.GetButton("Jump")) {
			Application.LoadLevel("stage-1");
		}

		if (Input.GetButton("Exit")) {
			Application.Quit();
		}
	}
}
