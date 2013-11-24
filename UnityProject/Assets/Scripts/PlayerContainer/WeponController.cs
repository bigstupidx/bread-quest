using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class WeponController : MonoBehaviour {

	public GameObject projectileJelly, projectilePB;

	void Update () {
		if ( Input.GetButtonDown("Fire1") ) {
			StartCoroutine(Attack (ElementType.JELLY));
		} else if ( Input.GetButtonDown("Fire2") ) {
			StartCoroutine(Attack (ElementType.PB));
		}
	}

	IEnumerator Attack(ElementType _projectile)
	{
		yield return new WaitForSeconds(0.5f);

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
			transform.parent.GetComponent<PlayerModel>().IsFacingRight()
		);
	}
}
