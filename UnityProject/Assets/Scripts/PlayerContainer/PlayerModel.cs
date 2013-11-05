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
	
	public int GetExperience()  { return experience; }
}
