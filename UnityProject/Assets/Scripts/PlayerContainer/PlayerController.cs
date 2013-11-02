using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
	
	const int MAX_SPEED = 20, MAX_ACCELERATION = 10, JUMP_SPEED = 200;
	
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
			currentSpeed = IncrementTowards(currentSpeed, targetSpeed);
		}
		
		Vector3 movement = new Vector3(currentSpeed, 0, 0);
		
		// processing vertical movements
		if(Input.GetButton("Jump") && isGrounded) {
			movement.y = JUMP_SPEED;
		}
	
		// applying movements to player
		transform.Translate(movement * Time.deltaTime);
	}
	
	float IncrementTowards(float _current, float _target) {
		float direction = Mathf.Sign(_target - _current);
		_current += MAX_ACCELERATION * direction;
		
		return direction == Mathf.Sign(_target - _current)
			   ? _current
			   : _target;
	}
	
	void OnCollisionEnter(Collision _collision) { isGrounded = _collision.gameObject.name == "Ground"; }
	void OnCollisionExit(Collision _collision)  { isGrounded = _collision.gameObject.name != "Ground"; }
}
