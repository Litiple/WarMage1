using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour {

	// 적군의 상태를 배열로 정의
	enum ENEMY // enum 의 이름이 SPIDERSTATE
	{
		IDLE = 0,
		MOVE,
		ATTACK,
		DAMAGE,
		DEAD
	}
	static ENEMY state;

	public Animation animation;
	UnityEngine.AI.NavMeshAgent agent;

	float stateTime = 0.0f;
	public float idleStateMaxTime = 1.0f;
	public float attackRange = 5.0f; // 공격 범위
	public float attackStateMaxTime = 2.0f; //공격 속도
	public static int healthPoint = 5;

	Transform target; // 타겟의 위치를 가져올 변수
	//PlayerState playerState;
	int skillPoint = 10; //필살기 포인트

	void Awake()
	{
		InitEnemy ();
	}

	void OnEnable() //OnDisable()
	{
		InitEnemy ();
	}

	void Start()
	{
		agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
		target = GameObject.Find("Door").transform;
	}

	void Update () 
	{
		switch (state) {
		case ENEMY.IDLE:
			Idle ();
			break;
		case ENEMY.MOVE:
			Move ();
			break;
		case ENEMY.ATTACK:
			Attack ();
			break;
		case ENEMY.DAMAGE:
			Damage();
			break;
		case ENEMY.DEAD:
			Dead ();
			break;
		}
	}

	public static void DamageByPlayer()
	{
		healthPoint -= 1;
		Debug.Log ("***");
		state = ENEMY.DAMAGE;
	}
	//Update => switch~case 
	void Idle()
	{
		// 2초간 대기
		stateTime += Time.deltaTime;
		if (stateTime > idleStateMaxTime) 
		{
			stateTime = 0.0f;
			state = ENEMY.MOVE;// move 로 상태 변경
		}
	}

	void Move()
	{
		// Player 위치 확인해서 Player 한테 다가감 => target
		animation.Play ("run");
		/*
		RaycastHit hit;
		if(Physics.Raycast(transform.position, transform.forward, out hit, 10))
		*/
		// 일정거리 안에 들어오면 공격 상태로 변경
		// attackRange 안에 있으면
		// state 를 ATTACK 으로 변경
		// 그렇지 않으면 이동
		// 1. 거리 계산
		//float distance = Vector3.Distance(target.position, transform.position);

		RaycastHit hit;

		agent.destination = target.position;

		if(Physics.Raycast(transform.position, transform.forward, out hit, 15))
		{
			Debug.Log ("Enemy search!");
			state = ENEMY.ATTACK;
		}
	}

	void Attack()
	{
		Debug.Log ("attack");
		//animation["attack1"].speed = 1.5f;
		// 공격
		animation.Play ("attack1");
		// stateTime 에 Time.deltaTime 누적 시켜서
		// attackStateMaxTime 보다 커지면 
		// 공격 animation 플레이
		// 끝나면 idle animation 플레이
		// 2초간 대기
		stateTime += Time.deltaTime;
		if (stateTime > attackStateMaxTime) {
			stateTime = 0.0f; // 초기화
			animation.Play ("attack1");
			//anim.CrossFade ("walk");
			animation.PlayQueued ("idle", QueueMode.CompleteOthers);
			//CastleState.DamageByEnemy ();
		}


		//distance 구해서 attackRange 보다 커지면
		//state를 MOVE
		float distance = (target.position - transform.position).magnitude;
		if (distance > attackRange) 
		{
			state = ENEMY.MOVE;
		}
	}

	void Damage()
	{
		animation.Play ("block_hit");
		animation.PlayQueued ("idle", QueueMode.CompleteOthers);

		stateTime = 0.0f;
		state = ENEMY.IDLE;

		//bool isDead = false;
		//if(isDead == true) // if(isDead)
		if (healthPoint <= 0) 
		{
			state = ENEMY.DEAD;
		}
	}

	void Dead()
	{
		// 죽는 애니메이션
		//Destroy(gameObject);
		StartCoroutine( DeadProcess() );
		//state = ENEMY.NONE;

		//ScoreManager.Instance ().myScore += score;
	}

	IEnumerator DeadProcess()
	{
		// play animation => "death1" 

		// play 중이면 기다리고
		// Destroy(gameObject);
		animation.Play("death");

		WaitForEndOfFrame waitForEndOfFrame = new WaitForEndOfFrame();

		while(animation.IsPlaying("death"))
		{
			yield return waitForEndOfFrame;
		}

		yield return new WaitForSeconds(1.0f);

		//GameObject explosionObj = Instantiate ();
		//Vector3 pos = transform.position;
		//pos.y = 0.6f;
		//explosionObj.transform.position = pos;
		// y 값만 0.6f 

		Destroy (gameObject);
		//InitEnemy();
		//gameObject.SetActive (false);
	}

	void InitEnemy()
	{
		healthPoint = 5;
		state = ENEMY.IDLE;
		animation.Play ("idle");
	}
}
