using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemyConfig", menuName = "LeProject/EnemyConfig", order = 1)]
public class EnemyConfig : ScriptableObject
{
	public string enemyName;
	public float h;
	public float aggroDistance;
	public float otherValue;
}
