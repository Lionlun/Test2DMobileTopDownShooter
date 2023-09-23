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
		if (data.Enemies.ContainsKey(Id))
		{
			transform.position = data.Enemies[Id];
		}

		if (data.DeadEnemies.Contains(Id))
		{
			data.Enemies.Remove(Id);
			this.gameObject.SetActive(false);
		}
	}

	public void SaveData(ref GameData data)
	{
		if (data.Enemies.ContainsKey(Id))
		{
			data.Enemies.Remove(Id);
		}

		data.Enemies.Add(Id, transform.position);
		if (isDead)
		{
			data.Enemies.Remove(Id);
			data.DeadEnemies.Add(Id);
		}
	}
}
