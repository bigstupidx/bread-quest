using UnityEngine;

public class ProjectileController : MonoBehaviour {
	public ProjectileType type;
	public float lifeTime;

	void Update() {
		lifeTime -= Time.deltaTime;
		
		if (lifeTime <= 0) {
			Destroy(gameObject);
		}
	}

	void FixedUpdate() {
		GetComponent<Rigidbody>().AddForce(Vector3.right * 10);
	}

	void OnTriggerEnter(Collider _c) {
		Debug.Log ("ProjectileController@OnTriggerEnter called");

		Destroy (_c.gameObject);
		Destroy (gameObject);
	}

	void OnCollisionEnter(Collision _c) {
		Debug.Log ("ProjectileController@OnCollisionEnter called");
		Destroy ( _c.gameObject);
		Destroy (gameObject);
	}
}
