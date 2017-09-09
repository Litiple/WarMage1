using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotate : MonoBehaviour 
{
	//화면 움직임 속도
	public float moveSpeed = 150.0f;
	float rotationX;
	float rotationY;

	void Update () 
	{

		// 마우스 입력값 받아오기
		float mouseMoveValueX = Input.GetAxis("Mouse X");
		float mouseMoveValueY = Input.GetAxis ("Mouse Y");

		rotationX = rotationX + (mouseMoveValueY * Time.deltaTime * moveSpeed);
		rotationY += mouseMoveValueX * Time.deltaTime * moveSpeed;

		//카메라의 x, y축 회전제한
		rotationX = Mathf.Clamp (rotationX, -90, 90);
		rotationY = Mathf.Clamp (rotationY, -90, 90);
		transform.eulerAngles = new Vector3 (-rotationX, rotationY, 0);
	}
}