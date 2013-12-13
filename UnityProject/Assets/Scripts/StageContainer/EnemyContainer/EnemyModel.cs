using UnityEngine;
using System.Collections;

public class EnemyModel : Person
{	
	new const int MAX_SPEED = 2;
	const int PROJECTILE_DAMAGE = 100;

	protected override IEnumerator ProcessDeath()
	{
		GetComponent<Animator>().SetTrigger("Die");
		yield return new WaitForSeconds(0.5f);

		Destroy(gameObject);
	}
}
