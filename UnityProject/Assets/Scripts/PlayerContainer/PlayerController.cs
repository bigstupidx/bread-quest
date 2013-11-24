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
		ProcessMovement();
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

		if (Input.GetButtonDown("Fire1")) {
			animator.Play("Attack-1");
		} else if (Input.GetButtonDown("Fire2")) {
			animator.Play("Attack-2");
		}

		// make actual movement
		controller.Move(movement * Time.deltaTime);
	}
}
