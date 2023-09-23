using UnityEngine;

[RequireComponent(typeof(ItemSpawn))]
public class EnemyDeath : DeathHandler
{
	private ItemSpawn itemSpawn;
	private GlobalEvents globalEvents = new GlobalEvents();

	private void Start()
	{
		itemSpawn = GetComponent<ItemSpawn>();
	}

	public override void Die()
	{
		itemSpawn.SpawnRandomItem(transform.position);
		globalEvents.SendEnemyDead();
		base.Die();
	}
}
