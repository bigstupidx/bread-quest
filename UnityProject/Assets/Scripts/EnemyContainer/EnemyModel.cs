using UnityEngine;

public class EnemyModel : Person {

	const int MAX_SPEED = 2;

	public bool hostile;

	public bool isHostile() {
		return true;
	}
}
