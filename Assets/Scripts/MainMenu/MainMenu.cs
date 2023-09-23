using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
	[SerializeField] private Button continueButton;

	private async void Start()
	{
		await Task.Delay(200);
		if (!DataManager.Instance.HasGameData())
		{
			continueButton.interactable = false;
		}
	}
	public void OnNewGamePressed()
	{
		DataManager.Instance.NewGame();
		DataManager.Instance.SaveGame();
		SceneManager.LoadSceneAsync(1);
	}
	public void OnContinuePressed()
	{
		DataManager.Instance.SaveGame();
		SceneManager.LoadSceneAsync(1);
	}
}
