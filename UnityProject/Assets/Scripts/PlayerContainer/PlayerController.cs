using UnityEngine;
using System.Collections;

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
	 * All movements applied to the character are processed here.
	 */
	public void ProcessMovement() {
		// process horizontal movement
		movement.x = Input.GetAxis("Horizontal") * PlayerModel.MAX_SPEED;

		animator.SetBool("isGrounded", controller.isGrounded);

		// if is jumping, apply gravity. Otherwise, process vertical movement.
		if ( ! controller.isGrounded ) {
		
			movement.y -= Physics.gravity.magnitude;
		
		} else if (Input.GetButtonDown("Jump")) {
		
			movement.y  = PlayerModel.JUMP_SPEED;
			animator.SetTrigger("Jump");

		}

		if (Input.GetButtonDown("Fire1")) {
			animator.SetTrigger("Attack-1");

		} else if (Input.GetButtonDown("Fire2")) {
			animator.SetTrigger("Attack-2");
		} else // if the player is moving, set animation to running
			animator.SetTrigger (
				movement.x == 0
				? "Idle"
				: "Run"
			);

		if (movement.x < 0 && model.IsFacingRight() || movement.x > 0 && !model.IsFacingRight()) {
			model.ToogleFacingDirection();
		}

		// make actual movement
		controller.Move(movement * Time.deltaTime);
	}
}
