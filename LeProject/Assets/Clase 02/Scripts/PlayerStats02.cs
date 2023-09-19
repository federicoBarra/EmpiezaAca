using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class PlayerStats02 : MonoBehaviour
{
	public PlayerInitialData data;

	[SerializeField]
	private float health = 100;

	public float Health
	{
		get => health;
		set => health = value;
	}
	public float HealthMax => data.healthMax;
	public float Speed => data.speed;

}
