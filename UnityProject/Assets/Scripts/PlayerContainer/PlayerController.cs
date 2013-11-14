using UnityEngine;

public class PlayerController : MonoBehaviour {
	
	Vector3 movement;
	CharacterController controller;
	
	void Start() {
		movement = new Vector3();
		controller = GetComponent<CharacterController>();
	}

	void Update() {
		ProcessMovement();
	}
	
	public void ProcessMovement() {
		movement.x = Input.GetAxis("Horizontal") * PlayerModel.MAX_SPEED;

		if (!controller.isGrounded) {
			movement.y -= Physics.gravity.magnitude;
		} else if (Input.GetButtonDown("Jump")) {
			movement.y = PlayerModel.JUMP_SPEED;
		}

		controller.Move(movement * Time.deltaTime);
	}
}
