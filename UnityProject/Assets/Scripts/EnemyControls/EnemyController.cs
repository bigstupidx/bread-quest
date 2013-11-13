using UnityEngine;
using System.Collections;

public class EnemyController : Person {

	//Enemy Handling
	public float gravity = 20;
	public float speed = 1;
	public float counter = 75;
//	public float walkSpeed = 8;
//	public float runSpeed = 12;
//	public float acceleration = 30;
//	public float jumpHeight = 12;
//	public float slideDecceleration = 10;
	
	
	int distFromStart = 0;
	
	//System
	private float animationSpeed;
	private float currentSpeed;
	private float targetSpeed;	
	private Vector2 amountToMove;
	
	//States
	private bool jumping;
	private bool sliding;
	private bool left;
	
	//Components
	private EnemyPhysics enemyPhysics;

	// Use this for initialization
	void Start () {
		enemyPhysics = GetComponent<EnemyPhysics>();
	}
	
	// Update is called once per frame
	void Update () {
		
		
		if(enemyPhysics.movementStopped)
		{
			//reset accel. when player hits wall
			targetSpeed = 0;
			currentSpeed = 0;
			
		}
		
		//scuttle left or right
		if (left)
		{
			amountToMove.x = speed;
			amountToMove.y -= gravity * Time.deltaTime;
			enemyPhysics.Move(amountToMove * Time.deltaTime);
		}
		else
		{
			amountToMove.x = -(speed);
			amountToMove.y -= gravity * Time.deltaTime;
			enemyPhysics.Move(amountToMove * Time.deltaTime);
		}
		
		//track movement
		if (left)
		{
			distFromStart++;
		}
		else
		{
			distFromStart--;
		}
		
		//change directions
		if (distFromStart >= counter || distFromStart <= -(counter))
			left = !left;
		
		
	}
	
	//Increase n towards target by speed
	private float IncrementTowards(float n, float target, float a) {
		if (n == target)
		{
			return n;
		}
		else
		{
			float dir = Mathf.Sign(target - n); //must n be increased or decreased to get closer to target
			n += a * Time.deltaTime * dir;
			return (dir == Mathf.Sign(target - n))? n: target; //if n has now passed target then return target, otherwise return n
					//(condition)? inside if: else
		}
	}//end IncrementTowards
	
	void OnTriggerEnter(Collider c)
	{
		if (c.tag == "Player")
		{
				c.GetComponent<PlayerModel>().Damage(PlayerModel.FALL_DAMAGE);
		}
		else if (c.tag == "Jelly")
		{
			
		}
		else if (c.tag == "PeanutButter")
		{
			
		}
	}
}
