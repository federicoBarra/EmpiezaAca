using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXManager : MonoBehaviour
{

	public static SFXManager instance;
	public static SFXManager Get => instance;
	public static bool Exists => instance != null;

	public enum MusicID
	{
		None,
		MainMenu,
		Level01
	}

	public AudioClip[] musics;
	public AudioSource musicSource;

	public MusicID currentMusic = MusicID.None;

// Start is called before the first frame update
	void Awake()
    {
	    if (instance)
	    {
			Destroy(this.gameObject);
	    }
	    else
	    {
		    musicSource = GetComponent<AudioSource>();
			instance = this;
			DontDestroyOnLoad(gameObject);
	    }
    }

	public void PlaySound(AudioClip clip, Vector3 pos)
	{
		AudioSource.PlayClipAtPoint(clip, pos);
	}


	public void PlayMusic(MusicID id)
	{
		//early exit
		if (currentMusic == id)
			return;

		currentMusic = id;
		musicSource.clip = musics[(int)currentMusic];
		musicSource.Play();
	}

}
