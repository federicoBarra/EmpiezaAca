using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Code05 : MonoBehaviour
{
	public AnimationCurve curvaLoca;

	public float duration;

	public float multiplierY = 3.14f;
	public float multiplierZ = 3.14f;

	private float t;

	public Gradient grad;
	public Material mat;

	void Start()
	{
		mat = GetComponent<Renderer>().material;
	}

	private float sign = 1;

    void Update()
    {
	    float value = curvaLoca.Evaluate(t / duration);
		Vector3 newPos = Vector3.zero;
		newPos.z = t / duration * multiplierZ;
		newPos.y = value * multiplierY;

		mat.color = grad.Evaluate(t / duration);

		transform.position = newPos;

        t += Time.deltaTime * sign;
        if (t >= duration)
        {
			if (sign > 0)
				sign = -1;
			else
				sign = 1;
        }
    }
}
