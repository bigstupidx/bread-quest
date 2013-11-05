using UnityEngine;
using System.Collections;

public class StageCamera : MonoBehaviour {
	
	public const int MIN_X = -10, MIN_Y = 5;
	
	Transform target;
	
	public void SetTarget(Transform t) {
		target = t;
	}
	
	void LateUpdate() {
		if (target) {
			float camX = transform.position.x;
			float camY = transform.position.y;
			float targetX = target.position.x > MIN_X ? target.position.x : MIN_X;
			float targetY = target.position.y > MIN_Y ? target.position.y : MIN_Y;
			
			float x = Tools.IncrementTowards(camX, targetX, Mathf.Abs(targetX - camX) * 1.5f);
			float y = Tools.IncrementTowards(camY, targetY, Mathf.Abs(targetY - camY) * 1.5f);
			
			transform.position = new Vector3(x, y, transform.position.z);
		}
	}
}
