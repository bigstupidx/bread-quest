using UnityEngine;
using System.Collections;

public class DoorController : MonoBehaviour {

	void OnTriggerCollider() {
		Application.LoadLevel("Win");
	}
}
