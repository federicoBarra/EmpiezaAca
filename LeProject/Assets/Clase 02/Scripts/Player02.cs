using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerInventory02))]
[RequireComponent(typeof(PlayerStats02))]
public class Player02 : MonoBehaviour
{
	private PlayerStats02 stats;

	private int dato;
	public int datoSerializadoPublic;
	
	[SerializeField]
	private int datoSerializadoPrivate;


	public float yOffset = 0.5f;
	public float attackDistance = 3;

	public float attackDamage = 20;

	public LayerMask layersQuePuedoAtacar;

	CharacterController controller;

	private Vector3 playerVelocity;
	private bool groundedPlayer;
	[Header("Controller data")]
	public float playerSpeed = 2.0f;
	public float jumpHeight = 1.0f;
	public float gravityValue = -9.81f;

	// Start is called before the first frame update
	void Awake()
	{
		stats = GetComponent<PlayerStats02>();

		stats.Health = stats.HealthMax;

		controller = gameObject.GetComponent<CharacterController>();
	}

	void Update()
	{
		if (Input.GetKeyDown(KeyCode.F))
			Attack();

		groundedPlayer = controller.isGrounded;
		if (groundedPlayer && playerVelocity.y < 0)
		{
			playerVelocity.y = 0f;
		}

		Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")).normalized;
		controller.Move(move * Time.deltaTime * playerSpeed);

		//gameObject.transform.Rotate();

		if (move != Vector3.zero)
		{
			gameObject.transform.forward = move;
		}

		// Changes the height position of the player..
		if (Input.GetButtonDown("Jump") && groundedPlayer)
		{
			playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
		}

		playerVelocity.y += gravityValue * Time.deltaTime;
		controller.Move(playerVelocity * Time.deltaTime);
	}

	void Attack()
	{
		RaycastHit hit;

		Vector3 rayOrigen = transform.position + Vector3.up * yOffset;
		Vector3 rayDirection = transform.forward;


		// Does the ray intersect any objects excluding the player layer
		if (Physics.Raycast(rayOrigen, rayDirection, out hit, attackDistance, layersQuePuedoAtacar))
		{
			Debug.DrawRay(rayOrigen, rayDirection * hit.distance, Color.yellow, 1f);
			Debug.Log("hit name: " + hit.transform.gameObject.name);

			IHittable hittable = hit.transform.gameObject.GetComponent<IHittable>();

			if (hittable != null)
				hittable.ReceiveDamage(attackDamage);
		}
		else
		{
			Debug.DrawRay(rayOrigen, rayDirection * attackDistance, Color.white, 1f);
		}
	}

	void ReceiveDamage(float damage)
	{
		stats.Health -= damage;

		if (stats.HealthMax < 0)
			Die();
	}

	public void Die()
	{
		Debug.Log("DIE");
	}
}
