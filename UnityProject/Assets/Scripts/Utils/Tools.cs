using UnityEngine;

public class Tools
{
	public static float IncrementTowards(float current, float target, float acceleration) {
		float dir = Mathf.Sign(target - current);
		current += Time.deltaTime * dir * acceleration;
		
		return (target - current) * dir > 0
			? current
			: target;
	}
}
