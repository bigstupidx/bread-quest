using UnityEngine;
using System.Collections;

public class PlayerModel : MonoBehaviour, IDamageable {

	public const int INITIAL_HEALTH = 100, INITIAL_EXPERIENCE = 0;
	
	int experience, health;
	
	public PlayerModel() {
		health = INITIAL_HEALTH;
		experience = INITIAL_EXPERIENCE;
	}
	
	public PlayerModel (int _health, int _experience,
		int _speed, int _rotateSpeed) {
		health = _health > 0
			   ? _health
			   : 0;
		experience = _experience > 0
				   ? _experience
				   : 0;
	}
	
	public void Damage( int _damage ) {
		health = health - _damage > 0
			   ? health - _damage
			   : 0;
	}
	
	public bool IsAlive()		{ return health > 0; }
	public int GetHealth() 		{ return health; 	 }
	public int GetExperience()  { return experience; }
}
