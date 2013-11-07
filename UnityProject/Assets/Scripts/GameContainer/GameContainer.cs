using System;
using UnityEngine;

public class GameContainer : MonoBehaviour
{
	public GameObject player;
	StageCamera cam;
	
	public void Start() {
		cam = GetComponent<StageCamera>();
		SpawnPlayer();
	}
	
	void SpawnPlayer() {
		cam.SetTarget((Instantiate(player, Vector3.up * 10, Quaternion.identity) as GameObject).transform);
	}
}
