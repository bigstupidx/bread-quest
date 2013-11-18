using UnityEngine;
using System.Collections.Generic;

public class WeponController : MonoBehaviour {

	public GameObject projectileJelly, projectilePB;

	void Update () {
		if ( Input.GetButtonDown("Fire1") ) {
			Attack (ProjectileType.JELLY);

		} else if ( Input.GetButtonDown("Fire2") ) {
			Attack (ProjectileType.PB);
		}
	}

	void Attack(ProjectileType _projectile) {
		Instantiate(
			_projectile == ProjectileType.JELLY ? projectileJelly : projectilePB,
			transform.position,
			Quaternion.identity
		);
	}
}
