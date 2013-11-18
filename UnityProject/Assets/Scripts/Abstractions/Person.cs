using UnityEngine;

public abstract class Person : MonoBehaviour, IDamageable
{
	public const int INITIAL_HEALTH = 100, INITIAL_EXPERIENCE = 0, MAX_SPEED = 10, JUMP_SPEED = 30,
		FALL_DAMAGE = 40, ENEMY_COLLISION_DAMAGE = 30, INITIAL_LIVES = 3;
	int health;
	int lives;

	bool isFacingRight = true;
	
	public Person() {
		health = INITIAL_HEALTH;
		lives = INITIAL_LIVES;
	}
	
	public Person (int _health) {
		health = _health >= 0
			   ? _health
			   : INITIAL_HEALTH;
	}
	
	public void Damage( int damageInflicted ) {
		health -= damageInflicted;

		if ( health <= 0 ) {
			health = 0;
			Die ();
		}

		Debug.Log("Damage inflicted. " + health + " health left.");
	}

	public bool IsFacingRight() {
		return isFacingRight;
	}

	public void ToogleFacingDirection() {
		isFacingRight = !isFacingRight;
		transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
	}

	public void Die() {
		lives--;
		health = INITIAL_HEALTH;
	}
	
	public bool IsAlive()		{ return health > 0; }
	public int GetHealth() 		{ return health; 	 }
}
