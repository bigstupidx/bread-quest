using UnityEngine;

public abstract class Person : MonoBehaviour, IDamageable
{
	public const int INITIAL_HEALTH = 100, INITIAL_EXPERIENCE = 0, MAX_SPEED = 10, JUMP_SPEED = 30,
		FALL_DAMAGE = 10;
	int health;
	
	public Person() {
		health = INITIAL_HEALTH;
	}
	
	public Person (int _health) {
		health = _health >= 0
			   ? _health
			   : INITIAL_HEALTH;
	}
	
	public void Damage( int _damage ) {
		health = health - _damage > 0
			   ? health - _damage
			   : 0;
	}
	
	public bool IsAlive()		{ return health > 0; }
	public int GetHealth() 		{ return health; 	 }
}
