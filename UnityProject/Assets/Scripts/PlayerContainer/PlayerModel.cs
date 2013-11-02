using UnityEngine;
using System.Collections;

public class PlayerModel : IDamageable {

	public const int INITIAL_HEALTH = 100, INITIAL_EXPERIENCE = 0, INITIAL_SPEED = 3, INITIAL_ROTATE_SPEED = 3;
	
	int experience, health, speed, rotateSpeed;
	
	public PlayerModel() {
		health = INITIAL_HEALTH;
		experience = INITIAL_EXPERIENCE;
		speed = INITIAL_SPEED;
		rotateSpeed = INITIAL_ROTATE_SPEED;
	}
	
	public PlayerModel (int _health, int _experience,
		int _speed, int _rotateSpeed) {
		health = _health > 0
			   ? _health
			   : 0;
		experience = _experience > 0
				   ? _experience
				   : 0;
		speed = _speed > 0
		 	  ? _speed
			  : 0;
		rotateSpeed = _rotateSpeed > 0
				    ? _rotateSpeed
				    : 0;
	}
	
	public void Damage( int _damage ) {
		health = health - _damage > 0
			   ? health - _damage
			   : 0;
	}
	
	public bool IsAlive()		{ return health > 0; }
	public int GetHealth() 		{ return health; }
	public int GetExperience()  { return experience; }
	public int GetSpeed() 	    { return speed; }
	public int GetRotateSpeed() { return rotateSpeed; }
}
