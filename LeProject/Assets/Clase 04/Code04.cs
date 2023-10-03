using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Code04 : MonoBehaviour
{
	public ParticleSystem ps;

	void Start()
	{
		ParticleSystem.MainModule mm = ps.main;

		mm.duration = 5;
		//ps.colorBySpeed.color = Color.black;
		//ps.main = mm;
	}

    // Update is called once per frame
    void Update()
    {
	    if (Input.GetKeyDown(KeyCode.Space))
	    {
            if (ps.isEmitting)
                ps.Stop(true, ParticleSystemStopBehavior.StopEmitting);
            else
            {
	            ps.Play();
            }
	    }
    }
}
