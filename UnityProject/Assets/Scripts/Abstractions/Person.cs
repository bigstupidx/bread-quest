	using UnityEngine;

public abstract class Person : MonoBehaviour, IDamageable
{
	public const int INITIAL_HEALTH = 100, INITIAL_EXPERIENCE = 0, MAX_SPEED = 10, JUMP_SPEED = 30,
		FALL_DAMAGE = 100, ENEMY_COLLISION_DAMAGE = 100, INITIAL_LIVES = 3;

	public ElementType type;

	int health;
	int lives;

	bool isFacingRight = true;
	
	public Person () {
		health = INITIAL_HEALTH;
		lives = INITIAL_LIVES;
	}

	public bool IsFacingRight() {
		return isFacingRight;
	}
	
	public virtual void ToogleFacingDirection() {
		isFacingRight = !isFacingRight;

		transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
	}
	
	public virtual void Damage( int damageInflicted ) {
		health -= damageInflicted;

		if ( health <= 0 ) {
			health = 0;
			Die ();
		}
	}

	public virtual void Die() {
		lives = lives - 1;

		if ( lives > 0 ) {
			health = INITIAL_HEALTH;
		}
	}

	public ElementType Type() {
		return type;
	}
	
	public bool IsAlive()		{ return health > 0; }
	public int GetHealth() 		{ return health; 	 }
	public bool HasLives()		{ return lives > 0;  }
	public int GetLives() 		{ return lives; 	 }
}
