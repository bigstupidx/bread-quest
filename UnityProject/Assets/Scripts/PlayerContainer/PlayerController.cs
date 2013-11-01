using UnityEngine;
using System.Collections;

[RequireComponent(typeof(PlayerPhysics))]
public class PlayerController : MonoBehaviour {
	
	public float speed = 12, acceleration = 8, gravity = 20;
	
	private float currentSpeed, targetSpeed;
	private Vector2 amountToMove;
	private PlayerPhysics playerPhysics;

	void Start () {
		playerPhysics = GetComponent<PlayerPhysics>();
	}
	
	void Update () {
		targetSpeed = Input.GetAxisRaw("Horizontal") * speed;
		
		if (currentSpeed != targetSpeed) {
			float initialDirection = Mathf.Sign(targetSpeed - currentSpeed);
			
			currentSpeed += Time.deltaTime * initialDirection;
			
			if (initialDirection != Mathf.Sign(targetSpeed - currentSpeed)) {
				currentSpeed = targetSpeed;
			}
		}
		
		amountToMove = new Vector2(currentSpeed * Time.deltaTime, 0);
		playerPhysics.Move(amountToMove);
	}
}
