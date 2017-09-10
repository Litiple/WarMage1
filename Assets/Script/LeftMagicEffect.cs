using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftMagicEffect : MonoBehaviour {
	public Transform leftExplosion;

	ParticleSystem leftExplosionPs;

	void Start () {
		if (leftExplosion) 
		{
			leftExplosionPs = leftExplosion.GetComponent<ParticleSystem>();
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
