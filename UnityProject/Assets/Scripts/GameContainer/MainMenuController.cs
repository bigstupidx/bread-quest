using UnityEngine;

public class MainMenuController : MonoBehaviour {

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
