using UnityEngine;

public class PlayerController : MonoBehaviour {
	
	Vector3 movement;
	CharacterController controller;
	
	void Start() {
		movement = new Vector3(0, 0, 0);
		controller = GetComponent<CharacterController>();
	}
	
	public void ProcessMovement() {
		movement.x = Input.GetAxis("Horizontal") * PlayerModel.MAX_SPEED;
		
		if (!controller.isGrounded) {
			movement.y -= Physics.gravity.magnitude;
		} else if (Input.GetButton("Jump")) {
			movement.y = PlayerModel.JUMP_SPEED;
		} else if (Input.GetKey(KeyCode.LeftShift)) {
			movement.x *= 1.5f;
		}
		
		controller.Move(movement * Time.deltaTime);
	}
}
