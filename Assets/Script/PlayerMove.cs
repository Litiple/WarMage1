using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour {

	//플레이어의 이동속도
	int speed = 10;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		//A,D 또는 방향키 입력받기
		float sideMove = Input.GetAxis ("Horizontal");
		//플레이어 이동
		transform.Translate (Vector3.right * sideMove * Time.deltaTime * speed);

		//x, y, z축 이동 제한
		transform.position = new Vector3(Mathf.Clamp(transform.position.x, -5.0f, 5.0f), 85, -48);
	}
}