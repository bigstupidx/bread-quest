using UnityEngine;

public class EnemyModel : Person
{	
	new const int MAX_SPEED = 2;
	const int PROJECTILE_DAMAGE = 100;

	public ElementType type;
	public bool hostile;

	public bool isHostile()
	{
		return true;
	}

	public override void Die ()
	{
		base.Die ();
		Destroy(gameObject);
	}
}
