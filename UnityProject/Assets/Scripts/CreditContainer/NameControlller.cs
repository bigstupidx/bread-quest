using UnityEngine;

public class NameControlller : MonoBehaviour
{
	void Start ()
	{
		iTween.FadeTo (gameObject, iTween.Hash(
			"alpha", .5f,
			"looptype", iTween.LoopType.pingPong,
			"easytype", iTween.EaseType.easeInOutSine
		));
	}

	void OnTriggerEnter(Collider _c)
	{
		float moveBy = Random.value * 5f;
		if ( moveBy < 2 )
			moveBy += 2;

		iTween.MoveBy(gameObject, iTween.Hash("y", moveBy, "looptype", iTween.LoopType.pingPong));
		iTween.ScaleBy(gameObject, iTween.Hash (
			"x", .75f,
			"easytype", iTween.EaseType.easeInOutElastic,
			"loopType", iTween.LoopType.pingPong
		));
	}
}
