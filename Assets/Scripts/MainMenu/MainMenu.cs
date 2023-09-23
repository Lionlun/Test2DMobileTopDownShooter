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
		SceneManager.LoadSceneAsync(0);
	}
	public void OnContinuePressed()
	{
		SceneManager.LoadSceneAsync(0);
	}
}
