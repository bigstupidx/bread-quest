public interface IDamageable {
	
	/**
	 * Damage: inflicts damage upon the object of the class which implements this interface.
	 * 
	 * @param damageInflicted: <integer> value which represents damage inflicted upon target.
	 * @return True, if IDamagable implementation was killed; False otherwise.
	 */
	bool Damage(int damageInflicted);
}
