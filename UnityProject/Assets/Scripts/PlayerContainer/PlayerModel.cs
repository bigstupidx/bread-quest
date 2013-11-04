using UnityEngine;

public class PlayerModel : MonoBehaviour, IDamageable {

	public const int INITIAL_HEALTH = 100, INITIAL_EXPERIENCE = 0, MAX_SPEED = 20, ACCELERATION = 10, JUMP_SPEED = 70;
	int experience, health;
	
	public PlayerModel() {
		health = INITIAL_HEALTH;
		experience = INITIAL_EXPERIENCE;
	}
	
	public PlayerModel (int _health, int _experience,
		int _speed, int _rotateSpeed) {
		health = _health >= 0
			   ? _health
			   : INITIAL_HEALTH;
		experience = _experience >= 0
				   ? _experience
				   : INITIAL_EXPERIENCE;
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
