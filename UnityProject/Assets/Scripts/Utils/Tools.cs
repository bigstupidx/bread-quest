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
	
	public static GameController GameController() {
		return Camera.main.GetComponent<GameController>();
	}

	public static bool IsNullObject(GameObject _o) {
		return _o.CompareTag("EnemyMovementInversionZone")
			|| _o.CompareTag("DeadZone");
	}

	public static GameObject Player() {
		return GameController().instantiatedPlayer;
	}
}
