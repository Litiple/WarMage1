using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMaker : MonoBehaviour {

	public GameObject enemy_GOBLINPrefab; //각 적군 유닛 프리팹
	/*
	public GameObject enemy_척탄병Prefab;
	public GameObject enemy_사다리Prefab;
	public GameObject enemy_골렘Prefab;
	public GameObject enemy_마녀Prefab;
	public GameObject enemy_충차Prefab;
	public GameObject enemy_보스Prefab;
*/
	//Goblin을 관리하기위한 Object pool
	public int GOBLIN_POOL_SIZE = 50; //고블린 전사 50마리
	GameObject []goblinPool;

	public float CREATE_TIME = 5f; //적 생성 시간 조절

	float currentTime = 0; //적 생성 관련 변수

	public float minSpawnPosX; //X축 최초 생성의 최소 좌표 값
	public float maxSpawnPosX; //X축 최초 생성의 최대 좌표 값

	public float minSpawnPosZ; //Z축 최초 생성의 최소 좌표 값
	public float maxSpawnPosZ; //Z축 최초 생성의 최대 좌표 값


	void Start () {
		//Object pool생성
		goblinPool = new GameObject[GOBLIN_POOL_SIZE];
		//pool에 객체 생성하여 집어넣기
		for(int i = 0; i < GOBLIN_POOL_SIZE; i++)
		{
			//고블린 객체 생성
			goblinPool [i] = Instantiate (enemy_GOBLINPrefab);
			//객체 비활성화(처음엔 모두 비활성화 상태로 진행
			goblinPool [i].SetActive (false);
		}
		//바로 생성 될 수 있도록 create_time값을 세팅	
		currentTime = CREATE_TIME;
	}

	void Update () {


		currentTime += Time.deltaTime; //적군 생성 딜레이 관련 내용

		if(currentTime > CREATE_TIME)
		{
			currentTime = 0;

			for(int i = 0; i < GOBLIN_POOL_SIZE; i++) //정해진 사이즈 값만큼 고블린 유닛을 생성하는 for반복문
			{
				if(goblinPool[i].activeSelf == false) //고블린이 꺼져있으면 다음 내용 실행
				{
					goblinPool [i].SetActive (true); //고블린 배열 생성
					//설정한 x와 z축 값으로 랜덤한 위치에 고블린을 생성
					goblinPool [i].transform.position = new Vector3(Random.Range(minSpawnPosX, maxSpawnPosX), 1, Random.Range(minSpawnPosZ, maxSpawnPosZ));
					break;
				}
			}
		}
	}
}