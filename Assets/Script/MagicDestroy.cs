using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicDestroy : MonoBehaviour {
	void OnCollisionEnter(Collision col)
	{
		Destroy (gameObject);
	}
}
