using UnityEngine;
using System.Collections;

public abstract class Person : MonoBehaviour, IDamageable
{
	public const int INITIAL_HEALTH = 100, INITIAL_EXPERIENCE = 0, MAX_SPEED = 10, JUMP_SPEED = 30,
		FALL_DAMAGE = 100, ENEMY_COLLISION_DAMAGE = 100, INITIAL_LIVES = 3;

	public ElementType type;

	int lives;
	int health;
	public bool vunerable;
	bool facingRight;


	public Person () {
		health = INITIAL_HEALTH;
		lives = INITIAL_LIVES;
		facingRight = true;
	}

	public bool FacingRight() {
		return facingRight;
	}
	
	public virtual void ToogleFacingDirection() {
		facingRight = !facingRight;
		transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
	}
	
	public virtual void Damage( int damageInflicted ) {
		if ( vunerable ) {
			vunerable = false;
			health -= damageInflicted;

			if ( health <= 0 ) {
				health = 0;
				Die ();
			}
		}
	}

	public virtual void Die() {
		lives = lives - 1;

		if ( lives > 0 ) {
			health = INITIAL_HEALTH;
		}

		StartCoroutine(ProcessDeath());
	}

	protected abstract IEnumerator ProcessDeath();

	public ElementType Type() {
		return type;
	}
	
	public bool IsAlive()		{ return health > 0; }
	public int GetHealth() 		{ return health; 	 }
	public bool HasLives()		{ return lives > 0;  }
	public int GetLives() 		{ return lives; 	 }
}
