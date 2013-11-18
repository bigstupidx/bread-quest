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

		if (Tools.IsNullObject(_c.gameObject)) {
			return;
		}

		if (_c.CompareTag("Enemy") && type != _c.GetComponent<EnemyModel>().type) {
			Destroy(_c.gameObject);
		}

		Destroy(gameObject);
	}
}
