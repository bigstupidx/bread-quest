using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
	
	public float speed = 3, rotateSpeed = 3;
	
	PlayerModel model;
	CharacterController controller;
	
	void Start () {
		model = new PlayerModel();
		controller = GetComponent<CharacterController>();
	}
	
	void Update() {
		ProcessMovement();
	}
	
	public void ProcessMovement () {
		transform.Rotate(0, Input.GetAxis("Horizontal") * model.GetRotateSpeed(), 0);
		
		Vector3 forward = transform.TransformDirection(Vector3.forward);
		float curSpeed = model.GetSpeed() * Input.GetAxis("Vertical");
		
		controller.SimpleMove(forward * curSpeed);
	}
}
