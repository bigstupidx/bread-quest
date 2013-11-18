using UnityEngine;

public abstract class Person : MonoBehaviour, IDamageable
{
	public const int INITIAL_HEALTH = 100, INITIAL_EXPERIENCE = 0, MAX_SPEED = 10, JUMP_SPEED = 30,
		FALL_DAMAGE = 100, ENEMY_COLLISION_DAMAGE = 100, INITIAL_LIVES = 3;
	int health;
	int init_health; //this is so that is the user specifies a health, it is reset to that
	int lives;

	bool isFacingRight = true;
	
	public Person() {
		health = INITIAL_HEALTH;
		lives = INITIAL_LIVES;
		init_health = health;
	}
	
	public Person (int _health) {
		health = _health >= 0
			   ? _health
			   : INITIAL_HEALTH;

		init_health = health;
	}
	
	public void Damage( int damageInflicted ) {
		health -= damageInflicted;

		if ( health <= 0 ) {
			health = 0;
			Die ();
		}

		Debug.Log("Damage inflicted. " + health + " health left. Lives: " + lives);
	}

	public bool IsFacingRight() {
		return isFacingRight;
	}

	public void ToogleFacingDirection() {
		isFacingRight = !isFacingRight;
		transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
	}

	public void Die() {
		lives = lives - 1 > 0 ? lives - 1 : 0;

		if (lives > 0)
			health = init_health;
	}
	
	public bool IsAlive()		{ return health > 0; }
	public int GetHealth() 		{ return health; 	 }
	public bool HasLives()		{ return lives > 0;  }
}
