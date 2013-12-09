using UnityEngine;
using System.Collections;

public class DoorController : MonoBehaviour {

	void OnTriggerEnter(Collider _c) {
		Application.LoadLevel("Win");
	}
}
