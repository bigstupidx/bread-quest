﻿using UnityEngine;
using System.Collections;

public class PlayerModel : Person
{
	public const float DEATH_TIME = 0.5f, UNVUNERABLE_TIME = 0.5f;

	public override void Damage(int _damage)
	{
		if (vunerable)
		{
			base.Damage (_damage);
			GetComponent<AudioSource>().Play();
		}
	}

	public override void Die()
	{
		base.Die ();
		Tools
			.GUIController()
			.DropLifeToken();
	}

	protected override IEnumerator ProcessDeath()
	{
		GetComponent<CharacterController>().enabled = false;
		GetComponent<Animator>().SetTrigger("Die");

		yield return new WaitForSeconds(DEATH_TIME);

		GetComponent<CharacterController>().enabled = true;
		GetComponent<Animator>().SetTrigger("Spawn");

		if ( IsAlive() )
			Tools.GameController().ResetPlayerPosition();
		else
			Application.LoadLevel("game-over");

		yield return new WaitForSeconds(UNVUNERABLE_TIME);
		vunerable = true;
	}
}
