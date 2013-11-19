using UnityEngine;

public class PlayerModel : Person {
	int experience;

	bool wasFacingRight;
	
	void Start() {
		experience = INITIAL_EXPERIENCE;
		wasFacingRight = IsFacingRight();
	}

	public bool WasFacingRight() {
		return wasFacingRight;
	}

	public override void ToogleFacingDirection() {
		wasFacingRight = IsFacingRight();
		base.ToogleFacingDirection();

		transform.Translate(-transform.localScale.x/2, 0, 0);
	}

	public void Damage(int _damage, bool _respawn) {
		Damage(_damage);

		if (_respawn) {
			Tools.GameContainer().ResetPlayerPosition();
		}
	}

	public override void Die ()
	{
		base.Die ();

		if ( !IsAlive() ) {
			Application.LoadLevel("game-over");
		}
	}
	
	public int GetExperience()  { return experience; }
}
