using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExampleSpinCapsule : MonoBehaviour {
	/*
	 * Used in the example scene and simply rotates capsules for visual reference.
	 * Example found at: https://unity3d.com/learn/tutorials/topics/scripting/spinning-cube
	 */
	public float speed = 10f;

	void Update () {
		transform.Rotate(Vector3.forward, speed * Time.deltaTime);
	}
}
