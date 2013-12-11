using System;
using UnityEngine;

public class GameController : MonoBehaviour
{
	public GameObject instantiatedPlayer;
	StageCamera cam;
	Vector3 position;

	public void Start() {
		cam = GetComponent<StageCamera>();
		SpawnPlayer();
	}

	public void Update() {
		if (Input.GetButton("Exit")) {
			Application.Quit();
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
