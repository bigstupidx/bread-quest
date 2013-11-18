using UnityEngine;

public class PlayerModel : Person {
	int experience;
	
	public PlayerModel() : base() {
		experience = INITIAL_EXPERIENCE;
	}
	
	public PlayerModel (int _health, int _experience) : base(_health) {
		experience = _experience >= 0
				   ? _experience
				   : INITIAL_EXPERIENCE;
	}

	public void Damage(int damageInflicted) {
		base.Damage(damageInflicted);

		if (!IsAlive()) {
			Application.LoadLevel("game-over");
		}
	}

	public void Damage(int _damage, bool _respawn) {
		Damage(_damage);

		if (_respawn) {
			Tools.GameContainer().ResetPlayerPosition();
		}
	}
	
	public int GetExperience()  { return experience; }
}
