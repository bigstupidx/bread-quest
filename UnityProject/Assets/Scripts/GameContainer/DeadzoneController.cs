using UnityEngine;
using System.Collections;

public class DeadzoneController : MonoBehaviour {

	void OnTriggerEnter (Collider _c) {
		if (_c.tag == "Player") {
			_c.GetComponent<PlayerModel>().Damage(PlayerModel.FALL_DAMAGE, true);
		}
	}
}
