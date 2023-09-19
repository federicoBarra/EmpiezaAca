using System;
using Unity.VisualScripting;
using UnityEngine;

public class LevelController : MonoBehaviour
{
	public LevelConfig data;
	private Player02 player;
	public int enemyCount;

	public static event Action OnLevelDataChanged;

	void Start()
	{
		player = FindAnyObjectByType<Player02>();

		CreateLevelEnemies();

		EnemyManager.OnAnEnemyDied += SeMurioUnEnemigo;

	}

	void OnDestroy()
	{
		EnemyManager.OnAnEnemyDied -= SeMurioUnEnemigo;
	}

	public void CreateLevelEnemies()
	{
		EnemyManager em = EnemyManager.Instance;

		for (int i = 0; i < data.enemiesCount; i++)
		{
			em.CreateEnemy(player.gameObject);
		}

		enemyCount = data.enemiesCount;
	}

	private void SeMurioUnEnemigo(Enemy02 obj)
	{
		enemyCount--;
		OnLevelDataChanged?.Invoke();
	}


	public void SpawnEnemiesMuajajajajja()
	{
		CreateLevelEnemies();
	}
}
