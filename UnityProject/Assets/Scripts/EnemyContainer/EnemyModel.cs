using UnityEngine;

public class EnemyModel : Person {

	const bool DEFAULT_HOSTILE = true;
	public bool hostile;

	public EnemyModel () {
		hostile = DEFAULT_HOSTILE;
	}

	public EnemyModel ( bool _hostile ) {
		hostile = _hostile;
	}

	public bool isHostile() {
		return true;
	}
}
