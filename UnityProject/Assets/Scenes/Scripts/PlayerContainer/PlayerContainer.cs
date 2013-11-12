using UnityEngine;

[RequireComponent (typeof (PlayerModel), typeof (PlayerController))]
public class PlayerContainer : MonoBehaviour
{
	PlayerModel model;
	PlayerController controller;
	
	void Start () {
		model 	   = GetComponent<PlayerModel>();
		controller = GetComponent<PlayerController>();
	}
	
	void Update() {
		controller.ProcessMovement();
	}
}
