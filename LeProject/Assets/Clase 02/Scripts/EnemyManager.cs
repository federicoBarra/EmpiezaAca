using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemyManager : MonoBehaviour
{
	public static EnemyManager Instance;
	public Enemy02 enemyPrefab;

	public static event Action<Enemy02> OnAnEnemyDied;


	void Awake()
	{
		if (Instance == null)
		{
			Instance = this;
		}
		else
		{
			Destroy(gameObject);
		}

		Enemy02.OnDie += SeMurioUnEnemigo;
	}

	void OnDestroy()
	{
		Enemy02.OnDie -= SeMurioUnEnemigo;
	}

	private void SeMurioUnEnemigo(Enemy02 obj)
	{
		OnAnEnemyDied?.Invoke(obj);
	}

	public Enemy02 CreateEnemy(GameObject target)
	{
		Enemy02 newEnemy = Instantiate(enemyPrefab);
		newEnemy.target = target;

		float random = Random.Range(-10f, 10f);

		newEnemy.transform.position = Vector3.forward * random;
		return newEnemy;
	}
}
