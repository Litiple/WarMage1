using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicDestroy : MonoBehaviour {
    public float currentTime = 0.0f;
    public float destroyTime = 4.0f;

    public Transform leftExplosion;
    ParticleSystem leftExplosionPs;

    void Start()
    {
        if (leftExplosion)
        {
            leftExplosionPs = leftExplosion.GetComponent<ParticleSystem>();
        }
    }

    private void Update()
    {
        currentTime += Time.deltaTime;
        if (currentTime > destroyTime)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(other.gameObject);
    }

    void OnCollisionEnter(Collision col)
	{
        ContactPoint contact = col.contacts[0];
        Quaternion rot = Quaternion.FromToRotation(Vector3.up, contact.normal);
        Vector3 pos = contact.point;
        Instantiate(leftExplosion, pos, rot);
        Debug.Log(pos);
        Destroy (gameObject);
        /*if (col.gameObject.name.Contains("LeftMarker"))
        {
            Destroy(col.gameObject);
        } */         
	}    
}
