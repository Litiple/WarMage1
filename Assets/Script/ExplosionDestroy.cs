using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionDestroy : MonoBehaviour {
	private float stateTime = 0.0f;
	public float destroyTime = 3.0f;
		
	void Update()
	{
		stateTime += Time.deltaTime;
		if(stateTime > destroyTime)
		{
			Destroy (gameObject);
		}
	}
}
