using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy04 : MonoBehaviour
{
    //BASIC FSM
    public Transform target;
    public float attackDistance = 3;
    public float idleTime = 5;
    public float someTimeAfterAttacking = 5;
	private float timer = 0;
    public enum EnemyState
    {
        Idle,
        FollowingPlayer,
        Attacking
    }

    public EnemyState currentState = EnemyState.Idle;

    // Update is called once per frame
    void Update()
    {
	    switch (currentState)
	    {
		    case EnemyState.Idle:
			    timer += Time.deltaTime;
				if (timer > idleTime)
					SetState(EnemyState.FollowingPlayer);
				break;
		    case EnemyState.FollowingPlayer:
				//aca muevo a mi enemy en direccion al target
			    //busco al player
			    //si esta a cierta distancia paso a Attacking
			    if (Vector3.Distance(transform.position, target.position)< attackDistance)
					SetState(EnemyState.Attacking);
				break;
		    case EnemyState.Attacking:
			    timer += Time.deltaTime;
			    if (timer > someTimeAfterAttacking)
				    SetState(EnemyState.FollowingPlayer);
				//ATTACK
				break;
	    }
    }

    public void SetState(EnemyState newState)
    {
	    currentState = newState;

	    switch (currentState)
	    {
		    case EnemyState.Idle:
			    timer = 0;
				break;
		    case EnemyState.FollowingPlayer:
			    break;
		    case EnemyState.Attacking:
			    timer = 0;
				//Launch Attack anim
				break;
	    }
    }

}
