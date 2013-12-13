using UnityEngine;
using System.Collections;

public class KnifeController : MonoBehaviour {

	const float LIFE_TIME = 1.5f, SPINNING_OFFSET = 0.5f;

	// control variable used to increase force to the corrent side in which the projectile was thrown
	bool goingRight = true;
	bool verticalMovement;
	bool hit = false;

	float offset = 0;

	/**
	 * Define if projectile executes a vertical movement.
	 * 
	 * @param _goingRight bool
	 */
	public void VerticalMovement(bool _vertical) {
		verticalMovement = _vertical;
	}

	/**
	 * Define direction of projectile.
	 * 
	 * @param _goingRight bool
	 */
	public void GoingRight(bool _goingRight) {
		goingRight = _goingRight;

		transform.localScale = new Vector3(
			(goingRight ?  1 : -1) * transform.localScale.x, transform.localScale.y, transform.localScale.z
		);
	}

	IEnumerator Destroy () {
		yield return new WaitForSeconds(LIFE_TIME);
		Destroy(gameObject);
	}

	/**
	 * Add movement to the projectile
	 */
	void FixedUpdate() {
		// if it hit something, all the forces must stop.
		if ( ! hit ) {
			// add force to the knife.
			GetComponent<Rigidbody>().AddForce(
				5 * ( verticalMovement
					? Vector3.down
					: (
						goingRight
						? Vector3.right
						: Vector3.left
					)
				)
	   		);

			// torque is not applicable to vertical movements.
			if (!verticalMovement) {
				// doesn't allow the knife to spin in the first SPINNING_OFFSET seconds.
				if (offset < SPINNING_OFFSET) {
					offset += Time.deltaTime;
				} else {
					GetComponent<Rigidbody>().AddTorque(
						// torque object always in down direction.
						new Vector3( 0, 0, goingRight ? -5 : 5 )
					);
				}
			}
		} else {
			GetComponent<Rigidbody>().AddForce(Vector3.down * 2);
		}
	}

	void OnTriggerEnter(Collider _c) {
		// the collider was the Player itself. Kill him.
		if ( _c.gameObject.CompareTag("Player") ) {
			_c.gameObject.GetComponent<PlayerModel>().Damage(PlayerModel.ENEMY_COLLISION_DAMAGE);

			Destroy(gameObject);
		} else {
			// the knife collided with something.
			hit = true;

			// the collider was something else. A wall, most likely. Wait LIFE_TIME and destroy the knife.
			StartCoroutine(Destroy ());
		}
	}
}
