using UnityEngine;

public class PlayerDeath : DeathHandler
{
	public override void Die()
	{
		Debug.Log("Player died");
		base.Die();
	}
}
