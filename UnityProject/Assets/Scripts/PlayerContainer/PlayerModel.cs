using UnityEngine;

public class PlayerModel : Person {
	int experience;

	void Start() {
		experience = INITIAL_EXPERIENCE;
	}

	void OnGUI() {
		GUI.Box(new Rect (10,10,100,50), "Lives: " + GetLives());
	}

	public override void Damage(int _damage) {
		base.Damage (_damage);

		if (IsAlive()) {
			GetComponent<AudioSource>().Play();
		}
	}

	public void Damage(int _damage, bool _respawn)
	{
		Damage(_damage);

		if (_respawn) {
			Tools.GameController().ResetPlayerPosition();
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
