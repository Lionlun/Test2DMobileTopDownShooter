using UnityEngine;

public class EnemySpawner : MonoBehaviour, IDataSave
{
    [SerializeField] EnemyBase enemyPrefab;
    private int enemiesNumber = 3;
	private SerializableDictionary<int, Vector3> existingIds = new SerializableDictionary<int, Vector3>();

    void Start()
    {
        for (int i = 0; i < enemiesNumber; i++)
        {
			if (existingIds.ContainsKey(i))
			{
				var oldEnemy = Instantiate(enemyPrefab, existingIds[i], Quaternion.identity);
				oldEnemy.SetId(i);
			}
			else
			{
				var randomPosition = GenerateRandomPosition();
				var enemy = Instantiate(enemyPrefab, randomPosition, Quaternion.identity);
				enemy.SetId(i);
			}
		}
    }

    private Vector2 GenerateRandomPosition()
    {
        var randomX = Random.Range(-4f, 6f);
        var randomY = Random.Range(-1.5f, 1.5f);
        return new Vector2(randomX, randomY);
    }

	public void LoadData(GameData data)
	{
		foreach(var enemy in data.EnemiesPosition)
		{
			existingIds.Add(enemy.Key, enemy.Value);
		}
	}

	public void SaveData(ref GameData data)
	{
		//Not Implemented yet
	}
}
