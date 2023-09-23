
public class PlayerHealth : Health, IDataSave
{
	public void LoadData(GameData data)
	{
		CurrentHealth = data.PlayerHealth;
		UpdateHealthUI();
	}

	public void SaveData(ref GameData data)
	{
		data.PlayerHealth = CurrentHealth;
	}
}
