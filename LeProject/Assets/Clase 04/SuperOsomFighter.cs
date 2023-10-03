using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuperOsomFighter : MonoBehaviour
{
	public AudioClip ac;
	public AudioSource swordSFX;
	public Transform swordAudioPos;
    // Start is called before the first frame update
    void Start()
    {
		//Esto seria en el gameManager o así
		if (SFXManager.Exists)
			SFXManager.Get.PlayMusic(SFXManager.MusicID.Level01);
	}

    // Update is called once per frame
    void Update()
    {
	    if (Input.GetKeyDown(KeyCode.Space))
	    {
		    //swordSFX.Play();
            if (SFXManager.Exists)
				SFXManager.Get.PlaySound(ac, swordAudioPos.position);

	    }
    }
}
