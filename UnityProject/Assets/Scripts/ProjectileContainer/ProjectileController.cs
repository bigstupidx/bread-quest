using UnityEngine;

public class ProjectileController : MonoBehaviour {
	public ElementType type;
	public float lifeTime;

	bool goingRight = true;

	public void GoingRight(bool _goingRight) {
		goingRight = _goingRight;

		if ( ! goingRight ) {
			transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
		}
	}

	public ElementType Type() {
		return type;
	}

	void Update() {
		lifeTime -= Time.deltaTime;
		
		if (lifeTime <= 0) {
			Destroy(gameObject);
		}
	}

	void FixedUpdate() {
		GetComponent<Rigidbody>().AddForce((goingRight ? Vector3.right : Vector3.left) * 10);
	}

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

		Destroy(gameObject);
	}
}
