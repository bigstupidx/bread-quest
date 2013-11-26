using UnityEngine;

public class EnemyModel : Person
{	
	new const int MAX_SPEED = 2;
	const int PROJECTILE_DAMAGE = 100;

	public override void Die ()
	{
		base.Die ();
		Destroy(gameObject);
	}
}
