using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class Tower : MonoBehaviour {

	public static Tower Instance;

	public int MAX_HP = 10;
	int hp = 0;

	public GameObject die;

	void Awake()
	{
        
		if(Instance == null)
			Instance = this;
	}

	void Start()
	{
        
		hp = MAX_HP;
	}

	public void Damage()
	{
		hp--;

		if(hp <= 0)
		{
			if(die)
			{
				die.SetActive(true);
			}
		}
	}
}
