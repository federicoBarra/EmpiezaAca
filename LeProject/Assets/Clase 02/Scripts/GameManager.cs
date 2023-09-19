using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
	public int score;

	public static GameManager Instance;

	void Awake()
	{
		if (Instance == null)
		{
			Instance = this;
			DontDestroyOnLoad(gameObject);
		}
		else
		{
			Destroy(gameObject);
		}
	}

	public void StartGame()
	{
		SceneManager.LoadScene("Clase 02");
	}

	void Update()
	{
		if (Input.GetKeyDown(KeyCode.Space))
			SaveGame();
		if (Input.GetKeyDown(KeyCode.F9))
			LoadSave();
	}

	public void SaveGame()
	{
		Player02 player02 = FindAnyObjectByType<Player02>();

		PlayerInventoryData pid = player02.GetComponent<PlayerInventory02>().data;

		string saveData = JsonUtility.ToJson(pid);

		Debug.Log("Save: " + saveData);

		PlayerPrefs.SetString("playerSave", saveData);
	}

	public void LoadSave()
	{
		string dataGuardadEnFormatoJson = PlayerPrefs.GetString("playerSave");

		Debug.Log("Load: " + dataGuardadEnFormatoJson);

		PlayerInventoryData newInventoryData = JsonUtility.FromJson<PlayerInventoryData>(dataGuardadEnFormatoJson);


		Player02 player02 = FindAnyObjectByType<Player02>();
		player02.GetComponent<PlayerInventory02>().data = newInventoryData;
	}
}
