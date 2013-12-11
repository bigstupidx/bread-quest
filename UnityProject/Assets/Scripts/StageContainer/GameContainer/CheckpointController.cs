using UnityEngine;
using System.Collections;

public class CheckpointController : MonoBehaviour {

	void OnTriggerEnter(Collider _c) {
		if (_c.CompareTag("Player")) {
			Tools.GameController().SetPlayerPosition(transform.position);
		}
	}
}
