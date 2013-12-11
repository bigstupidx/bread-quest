using UnityEngine;
using System.Collections;

public class ProjectileController : MonoBehaviour {
	// element of this projectile
	public ElementType type;
	// time (in seconds) in which the projectile does exists
	public float lifeTime;
	// control variable used to increase force to the corrent side in which the projectile was thrown
	bool goingRight = true;

	/**
	 * Define direction of projectile
	 * 
	 * @param _goingRight bool
	 */
	public void GoingRight(bool _goingRight) {
		goingRight = _goingRight;

		if ( ! goingRight ) {
			transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
		}
	}

	/**
	 * Return element of the projectile
	 * 
	 * @return ElementType
	 */
	public ElementType Type() {
		return type;
	}

	/**
	 * Asynchronous method WaitForLifeTime
	 * 
	 * @return IEnumerator
	 */
	IEnumerator WaitForLifeTime() {
		yield return new WaitForSeconds(lifeTime);
		Destroy();
	}

	void Destroy() {
		GameObject explosion = GameObject.Find("ProjectileExplosion");

		// show explosion effect
		explosion.transform.position = gameObject.transform.position;
		explosion.particleSystem.startColor
			= Type () == ElementType.JELLY
			? Color.magenta
			: Color.yellow
			;
		explosion.particleSystem.Play();

		// destroy projectile
		Destroy(gameObject);
	}

	void Start() {
		StartCoroutine(this.WaitForLifeTime());
	}

	/**
	 * Add movement to the projectile
	 */
	void FixedUpdate() {
		GetComponent<Rigidbody>().AddForce(10 * (
			goingRight
			? Vector3.right
			: Vector3.left
		));
	}

	/**
	 * Handles collision with objects
	 */
	void OnTriggerEnter(Collider _c) {
		// avoid collision with all undesired objects, like movement inversion zones or the player itself.
		if (Tools.IsNullObject(_c.gameObject) || _c.CompareTag("Player")) {
			return;
		}

		IDamageable target = _c.GetComponent(typeof(IDamageable)) as IDamageable;

		// target is damageable (because it implements the interface IDamageable)
		// and its type is different from the attack's type
		if (target != null && type != target.Type ()) {
			target.Damage(EnemyModel.ENEMY_COLLISION_DAMAGE);
		}

		this.Destroy();
	}
}
