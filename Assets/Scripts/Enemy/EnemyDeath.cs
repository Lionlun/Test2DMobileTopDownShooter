using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ItemSpawn))]
public class EnemyDeath : DeathHandler
{
	private ItemSpawn itemSpawn;

	private void Start()
	{
		itemSpawn = GetComponent<ItemSpawn>();
	}

	public override void Die()
	{
		itemSpawn.SpawnRandomItem(transform.position);
		base.Die();
	}
}
