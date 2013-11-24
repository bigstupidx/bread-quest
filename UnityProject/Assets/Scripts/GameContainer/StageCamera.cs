using UnityEngine;
using System.Collections;

public class StageCamera : MonoBehaviour {
	
	public const int MIN_X = 10, MIN_Y = 5, MAX_Y = 8, DIST_AHEAD_PLAYER = 5;
	
	Transform target;
	
	public void SetTarget(Transform t) {
		target = t;
	}
	
	void LateUpdate() {
		if (target) {
			float camX = transform.position.x;
			float camY = transform.position.y;
			float targetX;
			float targetY;

			if ( Tools.Player().GetComponent<PlayerModel>().IsFacingRight() ) {
				targetX = target.position.x + DIST_AHEAD_PLAYER;
			} else {
				targetX = target.position.x - DIST_AHEAD_PLAYER;
			}

			if (targetX < MIN_X) {
				targetX = MIN_X;
			}

			if (target.position.y > MAX_Y)
				targetY = MAX_Y;
			else if (target.position.y < MIN_Y)
				targetY = MIN_Y;
			else
				targetY = target.position.y;
			
			float x = Tools.IncrementTowards(camX, targetX, Mathf.Abs(targetX - camX) * 2f);
			float y = Tools.IncrementTowards(camY, targetY, Mathf.Abs(targetY - camY) * 2f);
			
			transform.position = new Vector3(x, y, transform.position.z);
		}
	}
}
