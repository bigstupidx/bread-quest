using UnityEngine;

public class PlayerModel : Person {
	int experience;

	bool wasFacingRight;
	
	public PlayerModel() : base() {
		experience = INITIAL_EXPERIENCE;
		wasFacingRight = IsFacingRight();
	}
	
	public PlayerModel (int _health, int _experience) : base(_health) {
		experience = _experience >= 0
				   ? _experience
				   : INITIAL_EXPERIENCE;
	}

	public bool WasFacingRight() {
		return wasFacingRight;
	}

	public void ToogleFacingDirection() {
		wasFacingRight = IsFacingRight();
		base.ToogleFacingDirection();
		transform.Translate(-transform.localScale.x/2, 0, 0);
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
		else {
			//destroy player object
		}
	}
	
	public int GetExperience()  { return experience; }
}
