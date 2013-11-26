using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	CharacterController controller;
	WeponController 	wepon;
	Vector3 			movement;
	Animator 			animator;
	PlayerModel 		model;

	void Start() {
		movement 	= Vector3.zero;
		model 		= GetComponent<PlayerModel>();
		wepon 		= gameObject.GetComponentInChildren<WeponController>();
		controller  = GetComponent<CharacterController>();
		animator 	= GetComponent<Animator>();
	}

	void Update() {
		ProcessMovement();
	}

	/**
	 * All movements applied to the character are processed here.
	 */
	public void ProcessMovement() {

		// process horizontal movement
		movement.x = Input.GetAxis("Horizontal") * PlayerModel.MAX_SPEED;
		animator.SetFloat("speed", Mathf.Abs(Input.GetAxis("Horizontal")));

		// facing direction change
		if (movement.x < 0 && model.FacingRight() || movement.x > 0 && !model.FacingRight()) {
			model.ToogleFacingDirection();
		}

		// if is jumping, apply gravity. Otherwise process vertical movement and animations.
		animator.SetBool("isGrounded", controller.isGrounded);

		if ( ! controller.isGrounded) {
			movement.y = movement.y - Physics.gravity.magnitude;
		} else {
			if (Input.GetButtonDown("Jump")) {
				movement.y  = PlayerModel.JUMP_SPEED;
				animator.SetTrigger("Jump");
			}
		}

		if ( ! wepon.IsFiring() ) {
			if (Input.GetButtonDown("Fire1")) {
				animator.SetTrigger("Attack-1");
				StartCoroutine(wepon.Attack (ElementType.JELLY));
			} else if (Input.GetButtonDown("Fire2")) {
				animator.SetTrigger("Attack-2");
				StartCoroutine(wepon.Attack (ElementType.PB));
			}
		}

		// make actual movement
		controller.Move(movement * Time.deltaTime);
	}
}
