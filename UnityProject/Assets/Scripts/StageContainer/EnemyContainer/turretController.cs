using UnityEngine;
using System.Collections;

public class turretController : MonoBehaviour {

	public GameObject knife;
	public float throwRate;

	void SpawnKnife() {
		GameObject instance;

		// turret is horizontally positioned.
		if ( transform.rotation.z != 0 ) {
			instance = Instantiate(knife, transform.position, Quaternion.AngleAxis(270f, Vector3.forward)) as GameObject;
		} else {
			instance = Instantiate(knife, transform.position, Quaternion.identity) as GameObject;
		}

		instance.GetComponent<KnifeController>().VerticalMovement(transform.rotation.z != 0);
		instance.GetComponent<KnifeController>().GoingRight(transform.localScale.x > 0);
	}

	void Start () {
		InvokeRepeating("SpawnKnife", 2f, throwRate);
	}
}
