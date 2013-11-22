using UnityEngine;

public class CrateModel : MonoBehaviour, IDamageable
{
	public ElementType type;

	public void Damage(int amount) {
		Destroy(gameObject);
	}

	public ElementType Type () {
		return type;
	}
}
