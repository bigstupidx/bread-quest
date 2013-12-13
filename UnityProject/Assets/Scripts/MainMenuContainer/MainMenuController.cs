using UnityEngine;

public class MainMenuController : MonoBehaviour
{
	void Update ()
	{
		if ( Input.GetButton("Enter") || Input.GetButton("Jump") )
		{
			Application.LoadLevel("intro");
		}
		else if ( Input.GetButton("Fire1") )
		{
			Application.LoadLevel("stage-1");
		}
		else if (Input.GetButton("Exit"))
		{
			Application.Quit();
		}
	}
}
