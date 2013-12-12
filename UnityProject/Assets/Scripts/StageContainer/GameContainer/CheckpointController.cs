using UnityEngine;
using System.Collections;

public class CheckpointController : MonoBehaviour {

	void OnTriggerEnter(Collider _c) {

		// checkpoint was reached by the player
		if (_c.CompareTag("Player")) {

			GetComponent<Animator>().SetTrigger("reached");
			Tools.GameController().SetPlayerPosition(transform.position);
		}
	}
}
