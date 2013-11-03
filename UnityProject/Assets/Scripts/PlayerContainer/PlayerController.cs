using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
	
	const int MAX_SPEED = 20, ACCELERATION = 10, JUMP_SPEED = 200;
	
	float currentSpeed, targetSpeed, jumpSpeed;
	
	bool isGrounded;
	
	void Start () {
		isGrounded = true;
		currentSpeed = targetSpeed = jumpSpeed = 0;
	}
	
	public void ProcessMovement () {
		targetSpeed = Input.GetAxis("Horizontal") * MAX_SPEED;
		
		// processing horizontal movement
		if (targetSpeed != currentSpeed) {
			// smothly increments speed towards target speed
			float direction = Mathf.Sign(targetSpeed - currentSpeed);
			currentSpeed += ACCELERATION * direction;
		}
		
		Vector3 movement = new Vector3(currentSpeed, 0, 0);
		
	
		// applying movements to player
		transform.Translate(movement * Time.deltaTime);
	}
	
	void OnCollisionEnter(Collision _collision) {
		jumpSpeed  = 0;
		isGrounded = _collision.gameObject.name == "Ground";
	}
	void OnCollisionExit(Collision _collision)  {
		isGrounded = _collision.gameObject.name != "Ground";
	}
}
