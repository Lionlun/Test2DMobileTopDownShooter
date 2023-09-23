using UnityEngine;

[RequireComponent(typeof(EnemyDeath))]
public class Enemy : EnemyBase, IDataSave
{
	private bool isDead;

	private void OnDisable()
	{
		isDead = true;
	}

	public void LoadData(GameData data)
	{
		if (data.EnemiesPosition.ContainsKey(Id))
		{
			transform.position = data.EnemiesPosition[Id];
		}

		if (data.DeadEnemies.Contains(Id))
		{
			data.EnemiesPosition.Remove(Id);
			this.gameObject.SetActive(false);
		}
	}

	public void SaveData(ref GameData data)
	{
		if (data.EnemiesPosition.ContainsKey(Id))
		{
			data.EnemiesPosition.Remove(Id);
		}

		data.EnemiesPosition.Add(Id, transform.position);
		if (isDead)
		{
			data.EnemiesPosition.Remove(Id);
			data.DeadEnemies.Add(Id);
		}
	}
}
