using UnityEngine;

public class PlayerController : MonoBehaviour {
	
	Vector3 movement;
	CharacterController controller;
	PlayerModel model;
	Animator animator;
	
	void Start() {
		movement = new Vector3(0, 0, 0);
		model = GetComponent<PlayerModel>();
		controller = GetComponent<CharacterController>();
		animator = GetComponent<Animator>();
	}

	void Update() {
		if (controller.enabled)
			ProcessMovement();
	}

	public void Active () {
		controller.enabled = true;
	}

	public void Deactive () {
		controller.enabled = false;
	}
	
	public void ProcessMovement() {
		// process horizontal movement
		movement.x = Input.GetAxis("Horizontal") * PlayerModel.MAX_SPEED;

		// if is jumping, apply gravity. Otherwise, process vertical movement.
		if (!controller.isGrounded) {
			movement.y -= Physics.gravity.magnitude;
		} else if (Input.GetButtonDown("Jump")) {
			movement.y = PlayerModel.JUMP_SPEED;
			animator.Play("Jumping");
		}

		if (movement.x < 0 && model.IsFacingRight() || movement.x > 0 && !model.IsFacingRight()) {
			model.ToogleFacingDirection();
		}

		animator.SetBool("running", movement.x != 0);

		// make actual movement
		controller.Move(movement * Time.deltaTime);
	}
}
