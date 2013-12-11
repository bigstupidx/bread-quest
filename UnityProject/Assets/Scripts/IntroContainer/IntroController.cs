using UnityEngine;
using System.Collections;

public class IntroController : MonoBehaviour {

	void Update() {
		if (Input.GetButton("Fire1")
		    || Input.GetButton("Fire2")
		    || Input.GetButton("Enter")
		    || Input.GetButton("Jump")) {
			SkipCinematic();
		}
	}

	/**
	 * Interrupts the cinematic and jumps to stage-1.
	 * It is called when the player presses any button or invoked by the
	 * Animator component at end of intro-layer-transitions.
	 */
	public void SkipCinematic () {
		Application.LoadLevel("stage-1");
	}
}
