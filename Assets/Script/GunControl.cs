using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class GunControl : MonoBehaviour {

	public Transform rightMagic;
	public Transform leftMagic;

	public Transform rightExplosion;
	public Transform leftExplosion;

	ParticleSystem rightEffectPs;
	ParticleSystem leftEffectPs;

	ParticleSystem rightExplosionPs;
	ParticleSystem leftExplosionPs;

	public float attackTime;

	void Start () 
	{
		if (rightMagic) 
		{
			rightEffectPs = rightMagic.GetComponent<ParticleSystem>();
		}
		if (rightExplosion) 
		{
			rightExplosionPs = rightExplosion.GetComponent<ParticleSystem>();
		}
		if (leftMagic) 
		{
			leftEffectPs = leftMagic.GetComponent<ParticleSystem>();
		}
		if (leftExplosion) 
		{
			leftExplosionPs = leftExplosion.GetComponent<ParticleSystem>();
		}
	}

	void Update () 
	{
		
		Ray ray = new Ray (Camera.main.transform.position, Camera.main.transform.forward);
		RaycastHit hitInfo;
		bool isHit = Physics.Raycast (ray, out hitInfo);

		if (isHit == true)
		{
			//draw crosshair
			//Debug.Log("isHit true");

			if (Input.GetButtonDown ("Fire1")) 
			{
				StartCoroutine ("AttackTime");

				Instantiate (rightEffectPs, hitInfo.point, transform.rotation);

				//CameraRotate.LeftClickFixe();

				if (hitInfo.transform.name.Contains ("Enemy")) 
				{
					Instantiate (rightExplosion, hitInfo.point, transform.rotation);
					Enemy.DamageByPlayer ();

				}
			} else if (Input.GetButtonDown ("Fire2")) 
			{
				Instantiate (leftEffectPs, hitInfo.point, transform.rotation);

				if (hitInfo.transform.name.Contains ("Enemy")) 
				{
					Instantiate (leftExplosion, hitInfo.point, transform.rotation);
					Enemy.DamageByPlayer ();
				}
			}
		}
	}
	IEnumerator AttackTime()
	{
		attackTime = 1.0f;
		yield return new WaitForSeconds (attackTime);
	}
}
