using UnityEngine;
using System.Collections;

public class PlayerPhysics : MonoBehaviour {
	
	private BoxCollider collider;
	private Vector3 s, c;
	
	private float skin = .005f;
	
	[HideInInspector]
	public bool grounded;
	public LayerMask collisionMask;
	
	Ray ray;
	RaycastHit hit;
	
	void Start() {
		collider = GetComponent<BoxCollider>();
		s = new Vector3();
		c = new Vector3();
	}
	
	public void Move(Vector2 moveAmount) {
		transform.Translate(moveAmount);
	}
}
