using UnityEngine;
using System.Collections;

public class KnifeController : MonoBehaviour {

	const float LIFE_TIME = 2f, SPINNING_OFFSET = 0.5f;

	// control variable used to increase force to the corrent side in which the projectile was thrown
	bool goingRight = true;
	bool hit = false;

	float offset = 0;

	/**
	 * Define direction of projectile
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
				10 * ( goingRight ? Vector3.right : Vector3.left )
	   		);

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
	}

	void OnCollisionEnter(Collision _c) {
		// the knife collided with something.
		hit = true;

		// the collider was the Player itself. Kill him.
		if ( _c.gameObject.CompareTag("Player") ) {
			_c.gameObject.GetComponent<PlayerModel>().Damage(PlayerModel.ENEMY_COLLISION_DAMAGE);
			Destroy(gameObject);
		} else {
			// the collider was something else. A wall, most likely. Wait LIFE_TIME and destroy the knife.
			StartCoroutine(Destroy ());
		}
	}
}
