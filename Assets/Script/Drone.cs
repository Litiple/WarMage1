using UnityEngine;
using System.Collections;

[RequireComponent(typeof(UnityEngine.AI.NavMeshAgent))]
public class Drone : MonoBehaviour {

	UnityEngine.AI.NavMeshAgent agent;

	Transform target;

	public float ATTACK_TIME = 2;
	float attackTime = 0;
	public int MAX_HP = 3;

	[System.NonSerialized]
	public int hp = 0;
	public float ATTACK_DISTANCE = 1;

	// Use this for initialization
	void Start () {
		agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
		target = GameObject.Find("Castle").transform;
		agent.destination = target.position;

		hp = MAX_HP;
		attackTime = ATTACK_TIME;
	}


	void Update()
	{
		
		if(agent.remainingDistance <= ATTACK_DISTANCE)
		{
			attackTime += Time.deltaTime;
			if(attackTime > ATTACK_TIME)
			{
				attackTime = 0;
				//Tower.Instance.Damage();
			}
		}
	}
}
