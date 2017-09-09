using UnityEngine;
using System.Collections;

public class CamRotate : MonoBehaviour {
	float RX;
	float RY;
	public float sensitivity = 500;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		#if UNITY_EDITOR
		float mx = Input.GetAxis("Mouse Y");
		float my = Input.GetAxis("Mouse X");

		RX += mx * sensitivity * Time.deltaTime;
		RY += my * sensitivity * Time.deltaTime;

		RX = Mathf.Clamp(RX, -60, 60);

		transform.eulerAngles = new Vector3(-RX, RY, 0);
		#endif
	}
}
