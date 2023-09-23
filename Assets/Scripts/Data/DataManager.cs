using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.SceneManagement;
using System.Threading.Tasks;

public class DataManager : MonoBehaviour
{
	[SerializeField] private string fileName;
	public static DataManager Instance { get; private set; }

	private GameData gameData;
	private List<IDataSave> dataSaves;
	private FileDataHandler dataHandler;

	private void OnEnable()
	{
		SceneManager.sceneLoaded += OnSceneLoaded;
		SceneManager.sceneUnloaded += OnSceneUnloaded;
	}

	private void OnDisable()
	{
		SceneManager.sceneLoaded -= OnSceneLoaded;
		SceneManager.sceneUnloaded -= OnSceneUnloaded;
	}

	private void Awake()
	{
		DontDestroyOnLoad(this.gameObject);

		if (Instance != null)
		{
			Debug.LogError("More than 1 DataManager!");
			Destroy(this.gameObject);
			return;
		}

		Instance = this;
		this.dataHandler = new FileDataHandler(Application.persistentDataPath, fileName);
	}

	public void NewGame()
	{
		this.gameData = new GameData();
	}

	public void LoadGame()
	{
		this.gameData = dataHandler.Load();

		if (this.gameData == null)
		{
			Debug.Log("No data found");
			return;
		}

		foreach(IDataSave dataSave in dataSaves)
		{
			dataSave.LoadData(gameData);
		}

	}
	public void SaveGame()
	{
		if (this.gameData == null)
		{
			Debug.Log("No data found. Start new game to save data");
			return;
		}
		foreach( IDataSave dataSave in dataSaves)
		{
			dataSave.SaveData(ref gameData);
		}
	
		dataHandler.Save(gameData);
	}

	public void ClearGameData()
	{
		this.gameData = null;
	}

	public async void OnSceneLoaded(Scene scene, LoadSceneMode mode)
	{
		await Task.Delay(100);
		this.dataSaves = FindAllDataSaveObjects();
		LoadGame();
	}
	public void OnSceneUnloaded(Scene scene)
	{
		SaveGame();
	}

	public bool HasGameData()
	{
		return this.gameData != null;
	}

	private void OnApplicationQuit()
	{
		SaveGame();
	}

	private List<IDataSave> FindAllDataSaveObjects()
	{
		IEnumerable<IDataSave> dataSaves = FindObjectsOfType<MonoBehaviour>(true).OfType<IDataSave>();
		return new List<IDataSave>(dataSaves);
	}
}
