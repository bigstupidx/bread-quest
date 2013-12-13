using System;
using UnityEngine;

public class GameController : MonoBehaviour
{
	public GameObject instantiatedPlayer;
	CameraController cam;
	Vector3 position;

	public void Start() {
		cam = GetComponent<CameraController>();
		SpawnPlayer();
	}

	public void Update() {
		if (Input.GetButton("Enter") || Input.GetButton("Exit")) {
			Application.LoadLevel("main-menu");
		}
	}
	
	void SpawnPlayer() {
		position = instantiatedPlayer.transform.position;
		this.ResetPlayerPosition();
		cam.SetTarget(instantiatedPlayer.transform);
	}
	
	public void ResetPlayerPosition() {
		instantiatedPlayer.transform.position = position + new Vector3(0, 1, 0);
	}

	public void SetPlayerPosition(Vector3 _position) {
		position = _position;
	}
}
