using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EntityHealth : MonoBehaviour
{
	public float maxHealth = 100;
	public float currentHealth = 0;

	public static event Action<EntityHealth> OnDie; 

    // Start is called before the first frame update
    void Start()
    {
	    currentHealth = maxHealth;
    }

    void ReceiveDamage(float damage)
    {
	    currentHealth -= damage;

        if (currentHealth < 0 )
            Die();
    }

    void Die()
    {
	    OnDie?.Invoke(this);
	}

    void OnCollisionEnter(Collision collision)
    {
        Debug.Log(name + " collisiono con : " + collision.gameObject.name);
	    ReceiveDamage(1000);

	    //foreach (ContactPoint contact in collision.contacts)
	    //{
	    //    Debug.DrawRay(contact.point, contact.normal, Color.white);
	    //}
	}
}
