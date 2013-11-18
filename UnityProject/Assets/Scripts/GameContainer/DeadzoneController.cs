using UnityEngine;
using System.Collections;

public class DeadzoneController : MonoBehaviour {

	void OnTriggerEnter (Collider _c) {
		if (_c.tag == "Player") {
			bool respawn = _c.GetComponent<PlayerModel>().HasLives();
			_c.GetComponent<PlayerModel>().Damage(PlayerModel.FALL_DAMAGE, respawn);
		}
	}
}
