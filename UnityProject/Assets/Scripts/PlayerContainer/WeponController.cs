using UnityEngine;
using System.Collections.Generic;

public class WeponController : MonoBehaviour {

	public GameObject projectileJelly, projectilePB;

	void Update () {
		if ( Input.GetButtonDown("Fire1") ) {
			//yield return new WaitForSeconds (1);

			Tools.Player().GetComponent<Animator>().Play("Attack-1");
			Attack (ElementType.JELLY);
		} else if ( Input.GetButtonDown("Fire2") ) {
			//yield return new WaitForSeconds (1);

			Tools.Player().GetComponent<Animator>().Play("Attack-2");
			Attack (ElementType.PB);
		}
	}

	void Attack(ElementType _projectile)
	{
		Debug.Log ("WeponController@Attack called");

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
