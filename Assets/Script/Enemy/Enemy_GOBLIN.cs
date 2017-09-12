using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_GOBLIN : MonoBehaviour {

	// 적군의 상태를 배열로 정의
	enum ENEMY // enum 의 이름이 SPIDERSTATE
	{
		NONE = -1, //존재하지 않음
		IDLE = 0, //대기
		MOVE, //이동
		ATTACK, //공격
		DAMAGE, //피해받음
		DEAD //죽음
	}
	static ENEMY state;

	public Animation animation;
	UnityEngine.AI.NavMeshAgent agent; //길찾기 대상(적군유닛)

	float stateTime = 0.0f; //상태 시간
	public float idleStateMaxTime = 1.0f; //대기 시간
	public float attackRange = 5.0f; // 공격 범위
	public float attackStateMaxTime = 2.0f; //공격 대기 시간
	public int healthPoint; //적군 유닛의 체력(입력)
	int enemyHP; //적군 유닛의 체력

	Transform target; // 타겟의 위치를 가져올 변수

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

	void InitEnemy()
	{
		animation.Play ("idle"); //대기 애니메이션
		enemyHP = healthPoint; // 적군유닛에게 입력한 체력 할당
		state = ENEMY.IDLE; //Idle로 상태 변경
	}

	void Idle()
	{
		// 1초간 대기
		stateTime = stateTime + Time.deltaTime;

		if (stateTime > idleStateMaxTime) //1초 이상 대기하면 실행
		{
			stateTime = 0.0f; //상태시간 초기화
			state = ENEMY.MOVE;// move로 상태 변경
		}
	}

	void Move()
	{
		animation.Play ("run"); //이동 애니메이션

		float distance = Vector3.Distance(target.position, transform.position); //타겟과 적군유닛간의 거리를 계산

		if(distance <= attackRange) //공격범위안에 들어오면 실행
		{
			//Debug.Log ("Enemy search and attack!");
			state = ENEMY.ATTACK; // 공격 상태로 변경
		}
		else
		{
			agent.destination = target.position;
		}
	}

	void Attack()
	{
		animation.Play ("attack1");//공격 애니메이션
		//animation["attack1"].speed = 1.5f;

		stateTime += Time.deltaTime;

		if (stateTime >= attackStateMaxTime) //공격 대기시간 이상이면 실행
		{
			stateTime = 0.0f; // 상태시간 초기화
			animation.Play ("attack1");//공격 애니메이션
			animation.PlayQueued ("idle", QueueMode.CompleteOthers);
		}

		float distance = Vector3.Distance(target.position, transform.position); //타겟과 적군유닛간의 거리를 계산

		if (distance > attackRange) //공격범위보다 거리가 크면 실행
		{
			state = ENEMY.MOVE; //이동 상태로 변경
		}
	}

	void OnCollisionEnter(Collision col)
	{
		//Debug.Log ("hit");
		if (state == ENEMY.NONE || state == ENEMY.DEAD) //상태가 NOEN 또는 DEAD라면 실행
		{
			return;
		}
		else if(col.gameObject.name.Contains("Magic") == true) //콜라이더가 있는 오브젝트 이름에 "Magic"이 포함되면 실행
		{
			state = ENEMY.DAMAGE;//피해 상태로 변경
		}
	}

	void Damage()
	{
		animation.Play ("block_hit"); //피해받는 애니메이션
		animation.PlayQueued ("idle", QueueMode.CompleteOthers);

		enemyHP -= 1; //적군유닛의 피해 처리
		Debug.Log(enemyHP);	

		state = ENEMY.IDLE; //이동 상태로 변경

		if (enemyHP <= 0) //유닛의 체력이 0이하라면 실행
		{
			state = ENEMY.DEAD; //죽음 상태로 변경
		}
	}

	void Dead()
	{
		StartCoroutine( DeadProcess() );

		state = ENEMY.NONE;

		//Destroy (gameObject);
		//ScoreManager.Instance ().myScore += score; 필살기 매니저로 관리 예정
	}

	IEnumerator DeadProcess()
	{
		animation.Play("death");

		WaitForEndOfFrame waitForEndOfFrame = new WaitForEndOfFrame();

		while(animation.IsPlaying("death"))
		{
			yield return waitForEndOfFrame;
		}

		yield return new WaitForSeconds(2.0f);

		//Destroy (gameObject);

		gameObject.SetActive(false);
	}
}