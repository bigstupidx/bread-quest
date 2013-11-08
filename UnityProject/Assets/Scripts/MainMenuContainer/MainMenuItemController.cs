using UnityEngine;
using System.Collections;

public class MainMenuItemController : MonoBehaviour {
	
	const float INITIAL_DELAY = 0, INCREASE_VALUE = 0.4f;
	static float delay;
	
	public string button;
	
	void Start () {
		Vector3 movement = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, 0);
		movement.x = -30;
		
		iTween.MoveTo(gameObject, iTween.Hash("x", -10, "easyType", "easeOutBounce", "time", 2, "delay", delay));
		delay += INCREASE_VALUE;
	}
	
	void Update() {
		// up or down key was pressed
		if (Input.GetAxisRaw("Vertical") != 0) {
			button = Input.GetAxisRaw("Vertical") == 1
				   ? "Play"
				   : "Exit";
		}
		
		if (Input.GetButton("Fire1") || Input.GetButton("Interact")) {
			ExecuteAction();
		}
	}
	
	void ExecuteAction() {
		if (button == "Play") {
			Application.LoadLevel("stage-1");
		} else if (button == "Exit") {
			Application.Quit();
		}
	}
}
