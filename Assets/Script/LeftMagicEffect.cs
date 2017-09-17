using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftMagicEffect : MonoBehaviour {
	public Transform leftExplosion;
	ParticleSystem leftExplosionPs;
	public float currentTime = 0.0f;
	public float destroyTime = 4.0f;

	void Start () {
		if (leftExplosion) 
		{
			leftExplosionPs = leftExplosion.GetComponent<ParticleSystem>();
		}
	}

	void Update()
	{
		currentTime += Time.deltaTime;
		if (currentTime > destroyTime) {
			Destroy (gameObject);
		}
	}


	void OnCollisionEnter(Collision col)
	{
		ContactPoint contact = col.contacts[0];
		Quaternion rot = Quaternion.FromToRotation (Vector3.up, contact.normal);
		Vector3 pos = contact.point;
		Instantiate (leftExplosion, pos, rot);
		Destroy (gameObject);
	}
}
