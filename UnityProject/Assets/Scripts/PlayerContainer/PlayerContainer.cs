using UnityEngine;
using System.Collections;

public class PlayerContainer : MonoBehaviour, IDamageable {
	
	const int INITIAL_HEALTH = 100, INITIAL_EXPERIENCE = 10;
	
	private int experience, health;
	
	public PlayerContainer () {
		health = INITIAL_HEALTH;
		experience = INITIAL_EXPERIENCE;
	}
	
	public bool Damage( int damage ) {
		health = health > damage
			   ? health - damage
			   : 0;

		return IsAlive();
	}
	
	public bool IsAlive() {
		return health > 0;
	}
}
