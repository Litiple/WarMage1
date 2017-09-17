using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightMarkDestroy : MonoBehaviour {
    public float currentTime = 0.0f;
    public float destroyTime = 6.0f;
    
	void Update () {
        currentTime += Time.deltaTime;
        if (currentTime > destroyTime)
        {
            Destroy(gameObject);
        }
	}
}
