using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;

public class AnimatorHandling : MonoBehaviour
{
	public Animator animator;

    void Start()
    {
	    animator = GetComponent<Animator>();
    }

    void Update()
    {





	    if (Input.GetKeyDown(KeyCode.Space))
	    {
            animator.SetTrigger("Attack");
	    }

	}
}
