using System;
using UnityEngine;

public class GameContainer : MonoBehaviour
{
	public GameObject originalPlayer, instantiatedPlayer;
	StageCamera cam;

	public void Start() {
		cam = GetComponent<StageCamera>();
		SpawnPlayer();
	}
	
	public void SpawnPlayer() {
		instantiatedPlayer = Instantiate(originalPlayer, Vector3.up * 10, Quaternion.identity) as GameObject;
		
		cam.SetTarget(instantiatedPlayer.transform);
	}
	
	public void ResetPlayerPosition() {
		Debug.Log("ResetPlayerPosition");
		instantiatedPlayer.transform.position = Vector3.up * 10;
	}
}
