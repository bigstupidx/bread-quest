using System;
using UnityEngine;

public class GameController : MonoBehaviour
{
	public GameObject originalPlayer, instantiatedPlayer;
	StageCamera cam;

	public void Start() {
		cam = GetComponent<StageCamera>();
		SpawnPlayer();
	}

	public void Update() {
		if (Input.GetButton("Exit")) {
			Application.Quit();
		}
	}
	
	public void SpawnPlayer() {
		instantiatedPlayer = Instantiate(originalPlayer, Vector3.up * 10, Quaternion.identity) as GameObject;
		
		cam.SetTarget(instantiatedPlayer.transform);
	}
	
	public void ResetPlayerPosition() {
		instantiatedPlayer.transform.position = Vector3.up * 10;
	}
}
