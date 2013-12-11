using UnityEngine;
using System.Collections.Generic;

public class GUIController : MonoBehaviour {

	List<GameObject> lifeTokens;

	void Start () {
		lifeTokens = new List<GameObject>(
			GameObject.FindGameObjectsWithTag("life-token")
		);
	}
	
	public void DropLifeToken() {
		Destroy(lifeTokens[lifeTokens.Count - 1]);
		lifeTokens.RemoveAt(lifeTokens.Count - 1);
	}
}
