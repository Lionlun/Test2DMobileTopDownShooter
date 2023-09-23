using UnityEngine;

public class EnemyHealth : Health, IDataSave
{
	[SerializeField] private EnemyBase enemy;

	public void LoadData(GameData data)
	{
		if (data.EnemyHealth.ContainsKey(enemy.Id))
		{
			CurrentHealth = data.EnemyHealth[enemy.Id];
			UpdateHealthUI();
		}
	}

	public void SaveData(ref GameData data)
	{
		if (data.EnemyHealth.ContainsKey(enemy.Id))
		{
			data.EnemyHealth.Remove(enemy.Id);
		}

		data.EnemyHealth.Add(enemy.Id, CurrentHealth);
	}
}
