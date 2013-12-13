using System;
using UnityEngine;

public class GameController : MonoBehaviour
{
	public GameObject instantiatedPlayer;

	Vector3 position;

	public void Start()
	{
		SpawnPlayer();
	}

	public void Update()
	{
		if ( Input.GetButton("Exit") )
			Application.LoadLevel("main-menu");
	}
	
	void SpawnPlayer()
	{
		position = instantiatedPlayer.transform.position;
		this.ResetPlayerPosition();
	}

	public void SetPlayerPosition(Vector3 _position)
	{
		position = _position;
	}

	public void ResetPlayerPosition()
	{
		instantiatedPlayer.transform.position = position + new Vector3(0, 1, 0);
	}
}
