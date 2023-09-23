using UnityEngine;
using System.Collections.Generic;

[System.Serializable]
public class GameData
{
    public int MonstersKilled;
    public Vector3 PlayerPosition;
    public List<Item> PlayerItems;
    public SerializableDictionary<int, Vector3> Enemies;
    public List<int> DeadEnemies;
    public int test;

	public GameData()
    {
        MonstersKilled = 0;
		PlayerItems = new List<Item>();
		PlayerPosition = Vector3.zero;
		Enemies = new SerializableDictionary<int, Vector3>();
		DeadEnemies = new List<int>();
        test = 0;
	}
}
