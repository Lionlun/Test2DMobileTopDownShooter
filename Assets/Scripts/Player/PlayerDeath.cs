using UnityEngine.SceneManagement;

public class PlayerDeath : DeathHandler
{
	public override void Die()
	{
		DataManager.Instance.ClearGameData();
		DataManager.Instance.SaveGame();
		SceneManager.LoadSceneAsync(0);
		base.Die();
	}
}
