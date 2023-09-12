using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class DataDeMiPersonaje
{
	[SerializeField]
	private float speed;
	public float Speed => speed;
}

public class MiPersonaje : MonoBehaviour
{
	public List<int> listaDeInt;
	public List<float> listaDeFloats;


	public float seconds = 0;
	public float secondsChoto = 0;

	[SerializeField]
	private float speed;

	[SerializeField]
	private DataDeMiPersonaje data;

	[SerializeField]
	private GameObject bullet;

	private float bulletInitialForce = 1000;
	private Rigidbody rigidbody;

	void Awake()
	{
		rigidbody = GetComponent<Rigidbody>();
		//bullet = GameObject.Find("Carlitos");
		Debug.Log("Pepe Awake");

		EntityHealth.OnDie += OnDie;

		listaDeInt.Add(14);
		listaDeInt.Add(50);

		//PrintData<MiPersonaje>(this);
		//PrintData<EntityHealth>(GetComponent<EntityHealth>());
	}

	void PrintData<T>(T dato) where T : MonoBehaviour
	{
		Debug.Log(dato.name);
	}


	// Start is called before the first frame update
	void Start()
    {
        Debug.Log("Start: " + gameObject.name);
		Debug.Log("transformPos: " + transform.position);
    }

	private Vector2 movement; // (x,y)

    // Corre junto con los FPS
    void Update()
    {
		//Debug.Log("Pepe Update");
		//float deltaTime = Time.deltaTime;
		//seconds += Time.deltaTime;
		//secondsChoto += 0.02f;

		Vector3 posicionActual = transform.position;
		//transform.position = new Vector3(posicionActual.x + speed * Time.deltaTime, posicionActual.y, posicionActual.z);

		movement = Vector2.zero;

		if (Input.GetKey(KeyCode.W))
			movement.y = 1;
		if (Input.GetKey(KeyCode.S))
			movement.y = -1;
		if (Input.GetKey(KeyCode.A))
			movement.x = -1;
		if (Input.GetKey(KeyCode.D))
			movement.x = 1;

		if (Input.GetKeyDown(KeyCode.Space))
		{
			GameObject newBullet = Instantiate(bullet, transform.position + transform.forward, Quaternion.identity);
			Rigidbody newBulletRig = newBullet.GetComponent<Rigidbody>();
			newBulletRig.AddForce(transform.forward * bulletInitialForce);

			Destroy(newBullet, 10);
		}
	}
	//void LateUpdate()
    //{
	//    //Debug.Log("Pepe LateUpdate");
	//
	//
	//
	//}

	//Corre con la fisica - Corre Physics step per second
    void FixedUpdate()
    {
	    Vector3 inputVector = new Vector3(movement.x, 0, movement.y); //(x,y,z)

	    rigidbody.AddForce(inputVector * data.Speed * Time.fixedDeltaTime);

		//Time.fixedDeltaTime

		//Debug.Log("Pepe FixedUpdate");
	}


    void OnDie(EntityHealth h)
    {
		Debug.Log(h.gameObject.name);

	    if (h.gameObject == gameObject)
	    {
			Debug.Log("Yo me mori");
	    }
    }
}
