using UnityEngine;
using System.Collections;

public class CreditsReturnController : MonoBehaviour {

	void OnTriggerEnter(Collider _c)
	{
		if ( _c.CompareTag("Player") )
		{
			_c.GetComponent<CharacterController>().enabled = false;
			_c.GetComponent<Animator>().SetFloat("speed", 0);
			StartCoroutine(ReturnToMainMenu());
		}
	}

	IEnumerator ReturnToMainMenu ()
	{
		yield return new WaitForSeconds(1f);
		Application.LoadLevel("main-menu");
	}
}
