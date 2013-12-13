using UnityEngine;
using System.Collections;

public class DeadzoneController : MonoBehaviour
{
	void OnTriggerEnter (Collider _c)
	{
		if ( _c.CompareTag("Player") )
			_c
				.GetComponent<PlayerModel>()
				.Damage(PlayerModel.FALL_DAMAGE);
	}
}
