using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerInitialData", menuName = "LeProject/PlayerInitialData", order = 1)]
public class PlayerInitialData : ScriptableObject
{
	public float initialHealth = 100;
	public float healthMax = 100;
	public float speed = 100;
}
