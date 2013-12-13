using UnityEngine;
using System.Collections;

public class SkipIconController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		iTween.ScaleBy(gameObject, iTween.Hash("x", 1.1f, "y", 1.1f, "looptype", iTween.LoopType.pingPong, "easetype", iTween.EaseType.easeInOutSine));
	}
}
