using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIMainMenu : MonoBehaviour
{
	public GameManager gm;

	public void PlayGame()
	{
		gm.StartGame();
	}
}
