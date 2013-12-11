public interface IDamageable {
	
	/**
	 * Damage: inflicts damage upon the object of the class which implements this interface.
	 * 
	 * @param damageInflicted: <integer> value which represents damage inflicted upon target.
	 */
	void Damage(int damageInflicted);

	/**
	 * Type: return the type of element associated with the object of the class which implements this interface.
	 * 
	 * @return ElementType
	 */
	ElementType Type ();
}
