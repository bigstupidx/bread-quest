using UnityEngine;
using System.Collections;

public class turretController : MonoBehaviour {

	public GameObject knife;
	public float throwRate;

	void SpawnKnife() {
		GameObject instance = Instantiate(knife, transform.position, Quaternion.identity) as GameObject;
		instance.GetComponent<KnifeController>().GoingRight(transform.localScale.x > 0);
	}

	void Start () {
		InvokeRepeating("SpawnKnife", 2f, throwRate);
	}
}
