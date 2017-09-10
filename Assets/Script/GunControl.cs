using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class GunControl : MonoBehaviour {


	public GameObject leftMagic;
	public GameObject rightMagic;

	public Transform leftMarker;
	public Transform rightMarker;

	ParticleSystem leftMarkerPs;
	ParticleSystem rightMarkerPs;


	public float attackTime;
	public float power = 20.0f;
	public float freezeTime = 0.5f;

	void Start () 
	{
		if (leftMarker) 
		{
			leftMarkerPs = leftMarker.GetComponent<ParticleSystem>();
		}
		if (rightMarker) 
		{
			rightMarkerPs = rightMarker.GetComponent<ParticleSystem>();
		}
	}

	void Update () 
	{
		
		Ray ray = new Ray (Camera.main.transform.position, Camera.main.transform.forward);
		RaycastHit hitInfo;
		bool isHit = Physics.Raycast (ray, out hitInfo);

		if (isHit == true)
		{
			if (Input.GetButtonDown ("Fire1")) 
			{
				Instantiate (leftMarkerPs, hitInfo.point, transform.rotation);
				GameObject obj = Instantiate (leftMagic);
				obj.transform.position = gameObject.transform.position;
				obj.GetComponent<Rigidbody> ().velocity = power * gameObject.transform.forward;
				//CameraRotate.LeftClickFixe();

				/*if (hitInfo.transform.name.Contains ("Enemy")) 
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
				}*/
			}
		}
	}
}
