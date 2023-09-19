using System;
using UnityEditor;
using UnityEngine;


public interface IHittable
{
	void ReceiveDamage(float damage);
	void Die();
}

public class Enemy02 : MonoBehaviour, IHittable
{
	public EnemyConfig data;
	public GameObject target;

	public bool isAggressive;

	public float health = 10;

	public static event Action<Enemy02> OnDie;

	//public event Action<Enemy02> OnDieDeInstancia;

	// Start is called before the first frame update
	void Start()
    {
        Debug.Log("enemy Name: " + data.enemyName);
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, target.transform.position) < data.aggroDistance)
        {
	        isAggressive = true;
        }

        if (isAggressive)
	        SearchPlayer();
    }

    private void SearchPlayer()
    {
	    //TODO hacer cosa
    }

    public void ReceiveDamage(float damage)
    {
	    health -= damage;
        if (health<0)
	        Die();
    }

    public void Die()
    {
        //if (OnDie!= null)
        //    OnDie(this);
        // esto es lo mismo que lo de abajo

        OnDie?.Invoke(this);
        Destroy(gameObject);
    }
}
