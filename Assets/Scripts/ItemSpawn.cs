using UnityEngine;
using Random = UnityEngine.Random;

public class ItemSpawn : MonoBehaviour
{
	[SerializeField] private ItemPickUp[] itemsToDrop;

	public void SpawnRandomItem(Vector3 position)
	{
		Instantiate(itemsToDrop[GetRandomIndex()], position, Quaternion.identity);
	}

	private int GetRandomIndex()
	{
		var randomIndex = Random.Range(0, itemsToDrop.Length);
		return randomIndex;
	}
}
