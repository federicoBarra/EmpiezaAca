using System.Collections;
using UnityEngine;

public class Cosas : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(transform.position);
        Debug.Log(transform.rotation.eulerAngles);
        Debug.Log(transform.localPosition);
        Debug.Log(transform.localRotation.eulerAngles);
	}

    public float attackTime = 1;
    public float releaseTime = 2;

    public float timer;

    public Animator animator;

// Update is called once per frame
	void Update()
	{
		timer -= Time.deltaTime;


		if (Input.GetKeyDown(KeyCode.Space) && timer<0)
			AttackNow02();

		//animator.SetFloat("AnimSpeed", 2);

    }


    public void AttackNow()
    {
	    timer = releaseTime;
		Debug.Log("Attack Time");
    }

    public void AttackNow02()
    {
	    timer = releaseTime;
	    StartCoroutine(AttackCorutine());
    }

    IEnumerator AttackCorutine()
    {
	    float t = releaseTime;
	    //animator.SetTrigger("Attack");
	    bool alreadyAttacked = false;

	    //yield return new WaitForSeconds(attackTime);

		while (t>0)
	    {
		    t -= Time.deltaTime;

		    if (t < 1 && !alreadyAttacked)
		    {
			    HacerElCheckeoDelAtaque();
			    alreadyAttacked = true;
		    }

		    yield return null;
	    }
	    Debug.Log("Termino de Atacar");
	}

    void HacerElCheckeoDelAtaque()
    {
		// Raycast
		//veo a quien le pego y le hago daño
    }


}
