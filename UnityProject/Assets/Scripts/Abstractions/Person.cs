using UnityEngine;

public abstract class Person : MonoBehaviour, IDamageable
{
	public const int INITIAL_HEALTH = 100, INITIAL_EXPERIENCE = 0, MAX_SPEED = 10, JUMP_SPEED = 30,
		FALL_DAMAGE = 10, INITIAL_LIVES = 3;
	int health;
	int lives;
	
	public Person() {
		health = INITIAL_HEALTH;
		lives = INITIAL_LIVES;
	}
	
	public Person (int _health) {
		health = _health >= 0
			   ? _health
			   : INITIAL_HEALTH;
	}
	
	public void Damage( int _damage ) {
		Debug.Log("Damage method called. Current health: " + health + ", damage: " + _damage);
		health = health - _damage > 0
			   ? health - _damage
			   : Die();
	}

	public void Die() {
		lives--;
		health = INITIAL_HEALTH;
	}
	
	public bool IsAlive()		{ return health > 0; }
	public int GetHealth() 		{ return health; 	 }
}
