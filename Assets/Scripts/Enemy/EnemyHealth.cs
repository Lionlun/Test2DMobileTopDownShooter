
using UnityEngine;

public class EnemyHealth : Health, IDataSave
{
	[SerializeField] private EnemyBase enemy;
	private int id;

	public void LoadData(GameData data)
	{
		id = enemy.Id;

		if (data.EnemyHealth.ContainsKey(id))
		{
			CurrentHealth = data.EnemyHealth[id];
			UpdateHealthUI();
		}
	}

	public void SaveData(ref GameData data)
	{
		if (data.EnemyHealth.ContainsKey(id))
		{
			data.EnemyHealth.Remove(id);
		}

		data.EnemyHealth.Add(id, CurrentHealth);
	}
}
