using UnityEngine;
using System.Collections.Generic;

[System.Serializable]
public class GameData
{
    public int MonstersKilled;
    public Vector3 PlayerPosition;
    public List<Item> PlayerItems;
    public int PlayerHealth;
    public SerializableDictionary<int, Vector3> EnemiesPosition;
	public SerializableDictionary<int, int> EnemyHealth;
	public List<int> DeadEnemies;

	public GameData()
    {
        MonstersKilled = 0;
		PlayerItems = new List<Item>();
        PlayerHealth = 100;
		PlayerPosition = new Vector3(-8, 0, 0);
		EnemiesPosition = new SerializableDictionary<int, Vector3>();
		EnemyHealth = new SerializableDictionary<int, int>();
		DeadEnemies = new List<int>();
	}
}
