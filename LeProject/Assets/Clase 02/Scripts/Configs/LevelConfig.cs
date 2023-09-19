using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "LevelConfig", menuName = "LeProject/LevelConfig", order = 1)]
public class LevelConfig : ScriptableObject
{
	public string LevelName;
	public int enemiesCount = 5;
}
