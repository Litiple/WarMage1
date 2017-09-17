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
		
		Ray ray = new Ray (Camera.main.transform.position, Camera.main.transform.forward); //Ray 형성
		RaycastHit hitInfo; // Ray 충돌지점 정보 
		bool isHit = Physics.Raycast (ray, out hitInfo); // Ray가 무언가에 부딪혔는지 확인

		if (isHit == true)
		{
			if (Input.GetButtonDown ("Fire1")) 
			{
				ParticleSystem firePs = Instantiate (leftMarkerPs, hitInfo.point, leftMarker.rotation); // 마커를 파티클시스템을 부딪힌 지점에 형성     
				GameObject obj = Instantiate (leftMagic); // 마법 구를 형성
				obj.transform.position = gameObject.transform.position; // 마법 구의 위치를 내 카메라의 위치로 이동
				obj.GetComponent<Rigidbody> ().velocity = power * gameObject.transform.forward; // 마법 구의 Rigidbody에서 Velocity 값을 카메라의 정면을 향하도록 설정

            } else if (Input.GetButtonDown ("Fire2")) 
			{
				ParticleSystem icePs = Instantiate (rightMarkerPs, hitInfo.point, rightMarker.rotation); // 마커를 파티클시스템을 부딪힌 지점에 형성     
				GameObject obj2 = Instantiate (rightMagic); // 마법 구를 형성
				obj2.transform.position = gameObject.transform.position; // 마법 구의 위치를 내 카메라의 위치로 이동
				//obj2.GetComponent<Rigidbody> ().velocity = power * gameObject.transform.forward; // 마법 구의 Rigidbody에서 Velocity 값을 카메라의 정면을 향하도록 설정
			}
        }
	}
}
