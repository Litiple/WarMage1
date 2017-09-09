using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour 
{
	public GameObject enemyPrefab;
	public float spawnTime = 2.0f;
	float deletaSpawnTime = 0.0f;

	int spawnCnt = 1;
	public int maxSpawnCnt = 10;
	//public PlayerState playerState;
	GameObject[] enemyPool;
	int poolSize = 10;

	void Start()
	{
		enemyPool = new GameObject[poolSize];
		for(int i = 0 ; i<poolSize ; i++)
		{
			enemyPool[i] = Instantiate (enemyPrefab);
			enemyPool [i].name = "Enemy_" + i;
			enemyPool [i].SetActive (false);
		}
	}

	void Update ()
	{
		/*
		if (playerState.isDead == true) {
			return;
		}
		*/
		if (spawnCnt > maxSpawnCnt) {
			return;
		}
		/*
		if ((playerState.isDead == true) || (spawnCnt > maxSpawnCnt)) {
			return;
		}
		*/
		SpawnEnemy ();

	}

		void SpawnEnemy()
		{
			deletaSpawnTime += Time.deltaTime;
			if (deletaSpawnTime > spawnTime) {
				deletaSpawnTime = 0.0f;

				//GameObject enemyObj = Instantiate (enemyPrefab);

				for (int i = 0; i < poolSize; i++) 
			{
					GameObject enemyObj = enemyPool [i];
					if (enemyObj.activeSelf == true) 
				{
						continue; //if condition is true, ignore remaind, go condition
				}

					float x = Random.Range (-20.0f, 20.0f);
					Vector3 pos = new Vector3 (x, 0.1f, 20.0f);
					enemyObj.transform.position = pos;

					enemyObj.SetActive (true);
					break;
					//enemyObj.name = "Enemy_" + spawnCnt;
					//spawnCnt = spawnCnt + 1;
					//spawnCnt++;
					//spawnCnt += 1;	
			}
		}
	}
}