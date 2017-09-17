using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicDestroy : MonoBehaviour {
	public float currentTime = 0.0f;
	public float destroyTime = 4.0f;

	void Update()
	{
		currentTime += Time.deltaTime;
		if (currentTime > destroyTime) {
			Destroy (gameObject);
		}
	}

	void OnCollisionEnter(Collision col)
	{
		Destroy (gameObject);
	}
}