using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class WeponController : MonoBehaviour {

	public AudioClip[] attackAudio;

	public GameObject projectileJelly, projectilePB;
	bool isFiring = false;

	public bool IsFiring() {
		return isFiring;
	}

	public IEnumerator Attack(ElementType _projectile)
	{
		isFiring = true;
		yield return new WaitForSeconds(0.3f);

		// instantiate projectile.
		GameObject projectile = Instantiate(
			_projectile == ElementType.JELLY
				? projectileJelly
				: projectilePB,
			transform.position,
			Quaternion.identity
		) as GameObject;

		// if player is facing the right direction, throw element to the right direction.
		// Throw element to the left direction, otherwise.
		projectile.GetComponent<ProjectileController>().GoingRight(
			transform.parent.GetComponent<PlayerModel>().FacingRight()
		);

		// play audioclip
		audio.clip = attackAudio[ _projectile == ElementType.JELLY ? 0 : 1 ];
		audio.Play();

		yield return new WaitForSeconds(0.2f);
		isFiring = false;
	}
}
