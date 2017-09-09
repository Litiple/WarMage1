using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyInvoke : MonoBehaviour 
{
	public float time = 2.0f;

	void Start () 
	{
		Invoke ("DestroyObj", time);
	}


	void DestroyObj()
	{
		Destroy (gameObject);
	}

}
