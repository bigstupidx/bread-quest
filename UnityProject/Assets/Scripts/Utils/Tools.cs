using UnityEngine;

public class Tools
{
	public static float IncrementTowards(float current, float target, float acceleration) {
		float dir = Mathf.Sign(target - current);
		current += dir * acceleration * Time.deltaTime;
		
		return (target - current) * dir > 0
			? current
			: target;
	}
	
	public static GameContainer GameContainer() {
		return Camera.main.GetComponent<GameContainer>();
	}

	public static bool IsNullObject(GameObject _o) {
		return _o.CompareTag("EnemyMovementInversionZone")
			|| _o.CompareTag("DeadZone");
	}
}
