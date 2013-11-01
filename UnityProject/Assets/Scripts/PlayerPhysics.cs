using UnityEngine;
using System.Collections;

public class PlayerPhysics : MonoBehaviour {
	
	private BoxCollider collider;
	private Vector3 size, centre;
	
	void Start() {
		collider = GetComponent<BoxCollider>();
		size = new Vector3();
	}
	
	public void Move(Vector2 moveAmount) {
		float deltaY = moveAmount.y;
		
		transform.Translate(moveAmount);
	}
}
