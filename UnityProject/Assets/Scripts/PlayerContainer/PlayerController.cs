using UnityEngine;

public class PlayerController : MonoBehaviour {

	CharacterController controller;
	Vector3 			movement;
	Animator 			animator;
	PlayerModel 		model;

	void Start() {
		movement 	= Vector3.zero;
		model 		= GetComponent<PlayerModel>();
		controller  = GetComponent<CharacterController>();
		animator 	= GetComponent<Animator>();
	}

	void Update() {
		if (controller.enabled) {
			ProcessMovement();
		}
	}

	/**
	 * Used by the animator
	 */
	public void Active () {
		controller.enabled = true;
	}

	/**
	 * Used by the animator
	 */
	public void Deactive () {
		controller.enabled = false;
	}

	/**
	 * All movements applied to the character are processed here.
	 */
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

		// if the player is moving, set animation to running
		animator.SetBool("running", movement.x != 0);

		// make actual movement
		controller.Move(movement * Time.deltaTime);
	}
}
