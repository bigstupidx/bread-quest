using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour
{	
	const int MIN_X = 7;
	const int MAX_X = 300;
	const int MIN_Y = 9;
	const int MAX_Y = 13;
	const int DIST_AHEAD_PLAYER = 5;
	
	Transform target;
	
	public void Start()
	{
		// Camera will always look for the character.
		target = GameObject.Find ("player").transform;
	}
	
	void LateUpdate()
	{
		// perform smooth transitions to the character.
		// the idea is quite simple: if the character is far from the camera focus, it will 
		// move fast and, as it's becomes near, it becomes to slow down.
		float camX = transform.position.x;
		float camY = transform.position.y;
		float targetX;
		float targetY;

		targetX = Tools.Player().GetComponent<PlayerModel>().FacingRight()
				? target.position.x + DIST_AHEAD_PLAYER
				: target.position.x - DIST_AHEAD_PLAYER
				;

		if ( targetX < MIN_X )
			targetX = MIN_X;
		else if ( targetX > MAX_X )
			targetX = MAX_X;

		targetY = target.position.y;

		if ( target.position.y < MIN_Y )
			targetY = MIN_Y;
		else if ( target.position.y > MAX_Y )
			targetY = MAX_Y;
		
		float x = Tools.IncrementTowards(camX, targetX, Mathf.Abs(targetX - camX) * 2f);
		float y = Tools.IncrementTowards(camY, targetY, Mathf.Abs(targetY - camY) * 2f);
		
		transform.position = new Vector3(x, y, transform.position.z);
	}
}
