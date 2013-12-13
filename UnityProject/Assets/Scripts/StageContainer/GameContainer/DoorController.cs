using UnityEngine;
using System.Collections;

public class DoorController : MonoBehaviour
{
	void OnTriggerEnter(Collider _c)
	{
		if ( _c.CompareTag("Player") )
			Application.LoadLevel("Win");
	}
}
