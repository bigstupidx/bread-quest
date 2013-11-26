using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour {

	EnemyModel model;

	void Start() {
		model = GetComponent<EnemyModel>();
	}

	void Update() {
		ProcessMovement();
	}

	void ProcessMovement() {
		transform.Translate(
			(model.FacingRight() ? Vector3.right : Vector3.left ) * 2 * Time.deltaTime
    	);
	}

	void OnTriggerEnter(Collider c) {
		if (c.CompareTag("EnemyMovementInversionZone")) {
			model.ToogleFacingDirection();
		}
		else if (c.gameObject.tag == "Player")
		{
			c.gameObject.GetComponent<PlayerModel>().Damage(PlayerModel.ENEMY_COLLISION_DAMAGE);
		}
	}
}
