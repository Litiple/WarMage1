using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class Gun : MonoBehaviour {
	public Transform bulletImpact;
	public Transform explosion;
	ParticleSystem bulletps;
	ParticleSystem explosionPs;


    Vector3 originSize;
	void Start()
	{
        if (bulletImpact)
			bulletps = bulletImpact.GetComponent<ParticleSystem>();
		if(explosion)
			explosionPs = explosion.GetComponent<ParticleSystem>();
	}
	// Update is called once per frame
	void Update () {
		//if(Input.GetButtonDown("Fire1"))
		{
			Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);
			RaycastHit hitInfo;

			if(Physics.Raycast(ray, out hitInfo))
			{
                
                if (Input.GetButtonDown("Fire1"))
                {
                    if (bulletImpact)
                    {
                        bulletImpact.up = hitInfo.normal;
                        bulletImpact.position = hitInfo.point + hitInfo.normal * 0.2f;
                        bulletps.Stop();
                        bulletps.Play();
                    }

                    if (hitInfo.transform.name.Contains("Enemy"))
                    {
                        if (explosion)
                        {
                            explosion.position = hitInfo.transform.position;
                            explosionPs.Stop();
                            explosionPs.Play();
                        }
                        //Destroy(hitInfo.transform.gameObject);
                    }
                }
                
			}
        }
	}
}
