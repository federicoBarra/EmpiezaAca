using TMPro;
using UnityEngine;

public class UILevelInfo : MonoBehaviour
{
	public TMP_Text levelName;
	public TMP_Text enemiesCount;

	private LevelController lc;

	void Awake()
	{
		lc = FindAnyObjectByType<LevelController>();
		levelName.text = lc.data.LevelName;

		LevelController.OnLevelDataChanged += RefreshUI;
	}

	private void RefreshUI()
	{
		enemiesCount.text = lc.enemyCount.ToString();
	}
}
