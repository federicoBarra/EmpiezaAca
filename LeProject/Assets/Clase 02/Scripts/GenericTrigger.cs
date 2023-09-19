using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GenericTrigger : MonoBehaviour
{
	public UnityEvent cosasALlamar;

	private void OnTriggerEnter(Collider other)
	{
		if (other.GetComponent<Player02>())
		{
			cosasALlamar?.Invoke();
		}
	}
}
