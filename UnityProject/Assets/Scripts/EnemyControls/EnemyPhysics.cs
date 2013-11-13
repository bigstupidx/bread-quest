using UnityEngine;
using System.Collections;

public class EnemyPhysics : MonoBehaviour {

	public LayerMask collisionMask;
	
	private BoxCollider collider;
	private Vector3 s; //size
	private Vector3 c; //center
	
	private Vector3 originalSize;
	private Vector3 originalCenter;
	private float colliderScale;
	
	private int collisionDivisionsX = 3;
	private int collisionDivisionsY = 10;
	
	private float skin = 0.005f;
	
	[HideInInspector]
	public bool grounded;
	
	[HideInInspector]
	public bool movementStopped;
	
	Ray ray;
	RaycastHit hit;
	
	void Start()
	{
		collider = GetComponent<BoxCollider>();
		colliderScale = transform.localScale.x;
		
		originalSize = collider.size;
		originalCenter = collider.center;
		SetCollider(originalSize, originalCenter);
	}
	
	public void Move(Vector2 moveAmount)
	{
		float deltaX = moveAmount.x;
		float deltaY = moveAmount.y;		
		Vector2 p = transform.position; //enemy pos
		

		
		//check collisions above and below
		grounded = false;
		for (int i = 0; i < collisionDivisionsX; i++)
		{
			float dir = Mathf.Sign (deltaY);
			float x = (p.x + c.x - s.x/2) + s.x/(collisionDivisionsX-1) * i; // Left, center, and then right point of collider
			float y = p.y + c.y + s.y/2 * dir; // Bottom of collider
			
			ray = new Ray(new Vector2(x, y), new Vector2(0, dir));
			Debug.DrawRay(ray.origin, ray.direction);
			
			if (Physics.Raycast (ray, out hit, Mathf.Abs(deltaY) + skin, collisionMask))
			{
				// Get Distance between enemy and ground
				float dst = Vector3.Distance (ray.origin, hit.point);
				
				// Stop enemy's downwards movement after coming within skin width of a collider
				if (dst > skin)
				{
					deltaY = dst * dir - skin * dir;
				}
				else
				{
					deltaY = 0;
				}
				
				grounded = true;
				break;
			}
		}
		
		//check collisions left and right
		movementStopped = false;
		for (int i = 0; i < collisionDivisionsY; i++)
		{
			float dir = Mathf.Sign (deltaX);
			float x = p.x + c.x + s.x/2 * dir;
			float y = p.y + c.y - s.y/2 + s.y/(collisionDivisionsY-1) * i;
			
			ray = new Ray(new Vector2(x, y), new Vector2(dir, 0));
			Debug.DrawRay(ray.origin, ray.direction);
			
			if (Physics.Raycast (ray, out hit, Mathf.Abs(deltaX) + skin, collisionMask))
			{
				// Get Distance between enemy and ground
				float dst = Vector3.Distance (ray.origin, hit.point);
				
				// Stop enemy's downwards movement after coming within skin width of a collider
				if (dst > skin)
				{
					deltaX = dst * dir - skin * dir;
				}
				else
				{
					deltaX = 0;
				}
				
				movementStopped = true;
				break;
			}
		}
		
		
		//diagonal movement check
		if (!grounded && !movementStopped)
		{
			Vector3 enemyDir = new Vector3(deltaX, deltaY);
			Vector3 o = new Vector3(p.x + c.x + s.x/2 * Mathf.Sign (deltaX), p.y + c.y + s.y/2 * Mathf.Sign (deltaY));
		
			ray = new Ray (o, enemyDir.normalized);
		
			if (Physics.Raycast(ray, Mathf.Sqrt(deltaX * deltaX + deltaY * deltaY), collisionMask))
			{
				grounded = true;
				deltaY = 0;
			}
		}
		
		Vector2 finalTransform = new Vector2(deltaX, deltaY);
		
		transform.Translate(finalTransform, Space.World);
	}
	
	
	public void SetCollider(Vector3 size, Vector3 center)
	{
		collider.size = size;
		collider.center = center;
		
		s = size * colliderScale;
		
		c = center * colliderScale;
	}
	
	public void ResetCollider()
	{
		SetCollider(originalSize, originalCenter);
	}
}
