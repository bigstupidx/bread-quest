using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour {

	EnemyModel model;

	void Start() {
		model = GetComponent<EnemyModel>();

		// horizontal movement
		iTween.MoveBy(gameObject, iTween.Hash(
			"x", 1.5,
			"easetype", "linear",
			"looptype","pingpong"
		));
	}

	void Update() {

	}

	void OnTriggerEnter(Collider c) {
		Debug.Log("EnemyController@OnTriggerEnter called.");
		if (c.gameObject.tag == "Player" && model.isHostile())
		{
			c.gameObject.GetComponent<PlayerModel>().Damage(PlayerModel.FALL_DAMAGE);
		}
		else if (c.gameObject.tag == "Jelly")
		{
			
		}
		else if (c.gameObject.tag == "PeanutButter")
		{
			
		}
	}
}
