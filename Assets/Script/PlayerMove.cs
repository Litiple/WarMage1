using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour {

	//플레이어의 이동속도
	int speed = 10;
	float stateTime = 0.0f;
	float freezeTime = 0.5f;


	void Start () {
		
	}

	void Update () {
		float sideMove = Input.GetAxis ("Horizontal");		//A,D 또는 방향키 입력받기
		transform.Translate (Vector3.right * sideMove * Time.deltaTime * speed);  //플레이어 이동
		transform.position = new Vector3(Mathf.Clamp(transform.position.x, -4.5f, 9.5f), 79, -73.4f); 		//x, y, z축 이동 제한
		if (Input.GetButtonDown("Fire1") == true) 
		{
			StartCoroutine ("Freeze");
		}
	}


	IEnumerator Freeze()
		{
			speed = 0;
			yield return new WaitForSeconds(freezeTime);
			speed = 10;
		}
			
	/*void SideMovement ()
	{
		float sideMove = Input.GetAxis ("Horizontal");		//A,D 또는 방향키 입력받기
		transform.Translate (Vector3.right * sideMove * Time.deltaTime * speed);  //플레이어 이동
	}*/
}