﻿using UnityEngine;

public class Particlesystem : MonoBehaviour {

	/**
	 * Allows the particle system to be seen in an 2D environment
	 */
	void Start () {
		renderer.sortingLayerName = "Enemy";
	}
}